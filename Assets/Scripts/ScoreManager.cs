using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    //public ������ ����Ƽ �ν�����â������ �����
    //[System.NonSerialized]


    //��������
    public TextMeshProUGUI currentScoreUI;
    private int currentScore;

    //�ְ�����
    public TextMeshProUGUI bestScoreUI;
    private int bestScore;

    //�̱��� ��ü : static(��������)�̱� ������ Ÿ ��ũ��Ʈ���� ���� ����
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;


    }


    private void Start()
    {
        //�ʱ�ȭ
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = $"{bestScore}";
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void SetScore(int value)
    {
        //3.���� ���
        currentScore = value;
        //4.���� ȭ�� ǥ��
        //currentScoreUI.text = $"{currentScore}";
        currentScoreUI.text = currentScore.ToString();

        //�ְ����� ǥ��
        if (currentScore > bestScore)
        {
            bestScore++;
            bestScoreUI.text = $"{bestScore}";

            //����Ƽ���� �����ϴ� ������ ������ : PlayerPrefs ��ü = key + value(int,float,string) ���� ����
            PlayerPrefs.SetInt("Best Score", bestScore);
        }


    }
}
