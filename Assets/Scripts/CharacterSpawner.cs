using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharacterType
{
    Warrior, Mage, Cleric, Thief, Popstar, Chef
}


public class CharacterSpawner : MonoBehaviour
{
    [SerializeField]
    private List<CharacterStatData> characterDatas;

    [SerializeField]
    private GameObject characterPrefab;

    private void Start()
    {
        for(int i = 0; i< characterDatas.Count; i++)
        {
            var character = CreateCharacter((CharacterType)i);
        }
    }

    public Character CreateCharacter(CharacterType type)
    {
        var newCharacter = Instantiate(characterPrefab).GetComponent<Character>();
        newCharacter.CharacterData = characterDatas[(int)type];
        newCharacter.watchCharacterInfo();
        return newCharacter;
    }



}
