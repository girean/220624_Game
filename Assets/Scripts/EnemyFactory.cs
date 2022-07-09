using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public float createTime = 2.0f;    //생성시간
    private float passTime = 0.0f;     //경과시간

    public GameObject enemyFactory;
    public float xRange = 6.0f; //팩토리의 X축 생성 범위

    //배경이미지 : 2048 * 2048

    public int enemySize = 10;
    public GameObject[] enemyObjectPool;

    private void Start()
    {
        //에너미풀을 에너미를 담을 수 있는 크기로 만들고
        enemyObjectPool = new GameObject[enemySize];

        for(int i = 0; i<enemySize; i++)
        {
            //에너미공장에서 에너미를 만들고
            GameObject enemy = Instantiate(enemyFactory);
            //에너미를 장전하고
            enemyObjectPool[i] = enemy;
            //에너미 비활성화
            enemy.SetActive(false);

        }

    }


    private void Update()       //왜? update에서 진행하면 안될까?
    {

        passTime += Time.deltaTime;


        //1.생성 후 일정시간이 지나면
        if(passTime > createTime)
        {
            for(int i = 0; i< enemySize; i++)
            {
                GameObject enemy = enemyObjectPool[i];
                //비활성화된 에너미가 있다면
                if(enemy.activeSelf == false)
                {
                    //활성화시키고
                    enemy.SetActive(true);
                    //3.enemy가 enemyFactory 위치에서 발사 
                    //팩토리의 X축 랜덤 생성 : 최대 6.0까지
                    enemy.transform.Translate(Random.Range(0.0f, xRange) * Time.deltaTime * Vector3.right);
                    break;
                }
            }

            passTime = 0.0f;

        }
    }



}
