using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScene : MonoBehaviour
{

    private void Awake()
    {
        Button restartButton = transform.Find("StartButton").GetComponent<Button>();
        restartButton.onClick.AddListener(SceneLoaded);
    }
    

    void SceneLoaded()
    {

        SceneManager.LoadScene("ShootingScene");
    }
}   
