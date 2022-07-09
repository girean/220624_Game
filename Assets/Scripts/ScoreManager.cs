using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    //public 이지만 유니티 인스펙터창에서는 사라짐
    //[System.NonSerialized]


    //현재점수
    public TextMeshProUGUI currentScoreUI;
    private int currentScore;

    //최고점수
    public TextMeshProUGUI bestScoreUI;
    private int bestScore;

    //싱글톤 객체 : static(전역변수)이기 때문에 타 스크립트에서 접근 가능
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;


    }


    private void Start()
    {
        //초기화
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = $"{bestScore}";
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void SetScore(int value)
    {
        //3.점수 계산
        currentScore = value;
        //4.점수 화면 표시
        //currentScoreUI.text = $"{currentScore}";
        currentScoreUI.text = currentScore.ToString();

        //최고점수 표시
        if (currentScore > bestScore)
        {
            bestScore++;
            bestScoreUI.text = $"{bestScore}";

            //유니티에서 제공하는 데이터 저장방식 : PlayerPrefs 객체 = key + value(int,float,string) 형태 저장
            PlayerPrefs.SetInt("Best Score", bestScore);
        }


    }
}
