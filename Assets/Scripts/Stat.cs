using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어와 몬스터의 공통 스탯
public class Stat : MonoBehaviour
{
    //Max 스탯
    [SerializeField]
    protected int maxHp;
    [SerializeField]
    protected int maxMp;
    [SerializeField]
    protected int maxAttack;
    [SerializeField]
    protected int maxMagic;
    [SerializeField]
    protected int maxDefence;
    [SerializeField]
    protected float maxSpeed;

    //개별 스탯
    protected int level;

    [SerializeField]
    protected int hp;
    [SerializeField]
    protected int attack;
    [SerializeField]
    protected int magic;
    [SerializeField]
    protected int defense;
    [SerializeField]
    protected int mp;
    [SerializeField]
    protected float speed;



    public int Level { get { return level; } set { level = value; } }

    public int HP { get => hp; set { hp = value; }}

    public int Attack { get => attack; set { attack = value; }}

    public int Magic { get => magic; set { magic = value; } }


    public int Defense { get => defense; set { defense = value; }}

    public int MP { get => mp; set { mp = value; }}

    public float Speed { get => speed; set { speed = value; } }


    private void Start()
    {
        int maxHp = 15;
        int maxMp = 8;
        int maxAttack = 12;
        int maxMagic = 7;
        int maxDefence = 6;
        float maxSpeed = 12;

    }




}
