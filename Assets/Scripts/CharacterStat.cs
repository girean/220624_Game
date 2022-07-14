using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : Stat
{
    public enum CharacterType
    {
        Warrior, Mage, Cleric, Thief, Popstar, Chef
    }



    private void Start()
    {
        
    }

    //전사
    int warriorHp = 12;
    int warriorMp = 4;
    int warriorAttack = 12;
    int warriorMagic = 0;
    int warriorDefence = 5;
    float warriorSpeed = 5;

    //마법사
    int mageHp = 10;
    int mageMp = 8;
    int mageAttack = 7;
    int mageMagic = 6;
    int mageDefence = 5;
    float mageSpeed = 10;

    //승려
    int clericHp = 10;
    int clericMp = 8;
    int clericAttack = 8;
    int clericMagic = 7;
    int clericDefence = 5;
    float clericSpeed = 11;

    //도적
    int thiefHp = 10;
    int thiefMp = 5;
    int thiefAttack = 8;
    int thiefMagic = 3;
    int thiefDefence = 6;
    float thiefSpeed = 12;

    //아이돌
    int popstarHp = 15;
    int popstarMp = 6;
    int popstarAttack = 6;
    int popstarMagic = 4;
    int popstarDefence = 4;
    float popstarSpeed = 6;

    //요리사 
    int chefHp = 9;
    int chefMp = 7;
    int chefAttack = 8;
    int chefMagic = 3;
    int chefDefence = 5;
    float chefSpeed = 5;



}
