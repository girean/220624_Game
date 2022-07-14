using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Character Stat Data", menuName = "Scriptable Object/Character Stat Data", /*순서라는데 뭘까?*/order = int.MaxValue)]

//캐릭터 생성
public class CharacterStatData : ScriptableObject
{
    [SerializeField]
    private string characterName;
    public string CharacterName { get { return characterName; } }

    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }

    [SerializeField]
    private int attack;
    public int Attack { get { return attack; } }

    [SerializeField]
    private int magic;
    public int Magic { get { return magic; } }

    [SerializeField]
    private int defense;
    public int Defense { get { return defense; } }

    [SerializeField]
    private int mp;
    public int Mp { get { return mp; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } }


}
