using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public Character character;

    //버튼 배열
    public Button[] buttons;

    

    private void Awake()
    {

        //buttons[0].onClick.AddListener(pressCharacter(int__warrior));
    }



    void Update()
    {

        //hpSlider.value = (float)warriorHp / maxHp;
        //mpSlider.value = (float)warriorMp / maxMp;
        //attackSlider.value = (float)warriorAttack / maxAttack;
        //magicSlider.value = (float)warriorMagic / maxMagic;
        //defenceSlider.value = (float)warriorDefence / maxDefence;
        //speedSlider.value = (float)warriorSpeed / maxSpeed;



    }

    private void OnMouseUpAsButton()
    {
        //CharacterStatManager.instance.currentCharacter = character;
        
    }

    void OnSelect()
    {

    }



    //1. 버튼을 누르면 캐릭터 설명이 바뀐다
    //2. 동시에 스탯바의 값도 바뀐다.

    public Slider hpSlider;
    public Slider mpSlider;
    public Slider attackSlider;
    public Slider magicSlider;
    public Slider defenceSlider;
    public Slider speedSlider;


    RectTransform barfill;



}
