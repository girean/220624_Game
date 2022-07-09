using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;


//�ε��� UI ���̵���/���̵�ƿ� 
public class LoadingSceneController : MonoBehaviour
{

    private static LoadingSceneController instance;

    public static LoadingSceneController Instance
    {
        get
        {
            if(instance == null)
            {
                var obj = FindObjectOfType<LoadingSceneController>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    instance = Create();
                }
            }

            return instance;
        }
    
    }

    private static LoadingSceneController Create()
    {
        //why? prefabs �����̸����δ� �ȵǰ� resources ���� �̸����δ� ����?
        return Instantiate(Resources.Load<LoadingSceneController>("LoadingUi"));
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Image progressBar;

    private string loadingSceneName;

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        SceneManager.sceneLoaded += OnSceneLoaded;
        loadingSceneName = sceneName;
        StartCoroutine(loadSceneProcess());

    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == loadingSceneName)
        {
            StartCoroutine(Fade(false));
            //�������� ������ �ݹ��� ��ø��_�̸� ����
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }


    }

    private IEnumerator loadSceneProcess()
    {
        progressBar.fillAmount = 0f;

        //�� �ڿ������� ������
        yield return StartCoroutine(Fade(true));

        //�񵿱�� ���� �ҷ����̴� �۾�
        AsyncOperation op = SceneManager.LoadSceneAsync(loadingSceneName);
        //�ڵ����� �� ��ȯ���� �ʵ���
        op.allowSceneActivation = false;

        //�ε��ٰ� �����̵���
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1.0f, timer);
                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }


    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0.0f;
        while(timer <= 1.0f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 3f;
            canvasGroup.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer); 
        }

        if (!isFadeIn)
        {
            gameObject.SetActive(false);
        }
    }




}



