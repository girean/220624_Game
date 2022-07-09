using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;


//로딩바 UI 페이드인/페이드아웃 
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
        //why? prefabs 폴더이름으로는 안되고 resources 폴더 이름으로는 되지?
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
            //제거하지 않으면 콜백이 중첩됨_이를 방지
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }


    }

    private IEnumerator loadSceneProcess()
    {
        progressBar.fillAmount = 0f;

        //씬 자연스럽게 가리며
        yield return StartCoroutine(Fade(true));

        //비동기로 씬을 불러들이는 작업
        AsyncOperation op = SceneManager.LoadSceneAsync(loadingSceneName);
        //자동으로 씬 전환하지 않도록
        op.allowSceneActivation = false;

        //로딩바가 움직이도록
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



