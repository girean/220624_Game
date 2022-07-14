using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterStatManager : MonoBehaviour
{
    public static CharacterStatManager instance;

    //public Character currentCharacter;

    
    [SerializeField]
    private GameObject[] characters;

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneloaded;
        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }


    }


    private void OnSceneloaded(Scene arg0, LoadSceneMode arg1)
    {


    }


    public void Changecharacter(int index)
    {
        for(int i= 0; i<characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        characters[index].SetActive(true);
    }


    public void SelectWeapon()
    {
        SceneManager.LoadScene(1);
        
        
    }



}
