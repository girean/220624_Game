using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterStatData characterData;
    public CharacterStatData CharacterData { set { characterData = value; } } 

    public void watchCharacterInfo()
    {

        Debug.Log($"ĳ�����̸� : {characterData.CharacterName}");

    }


}
