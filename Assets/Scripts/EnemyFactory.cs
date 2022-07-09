using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public float createTime = 2.0f;    //�����ð�
    private float passTime = 0.0f;     //����ð�

    public GameObject enemyFactory;
    public float xRange = 6.0f; //���丮�� X�� ���� ����

    //����̹��� : 2048 * 2048

    public int enemySize = 10;
    public GameObject[] enemyObjectPool;

    private void Start()
    {
        //���ʹ�Ǯ�� ���ʹ̸� ���� �� �ִ� ũ��� �����
        enemyObjectPool = new GameObject[enemySize];

        for(int i = 0; i<enemySize; i++)
        {
            //���ʹ̰��忡�� ���ʹ̸� �����
            GameObject enemy = Instantiate(enemyFactory);
            //���ʹ̸� �����ϰ�
            enemyObjectPool[i] = enemy;
            //���ʹ� ��Ȱ��ȭ
            enemy.SetActive(false);

        }

    }


    private void Update()       //��? update���� �����ϸ� �ȵɱ�?
    {

        passTime += Time.deltaTime;


        //1.���� �� �����ð��� ������
        if(passTime > createTime)
        {
            for(int i = 0; i< enemySize; i++)
            {
                GameObject enemy = enemyObjectPool[i];
                //��Ȱ��ȭ�� ���ʹ̰� �ִٸ�
                if(enemy.activeSelf == false)
                {
                    //Ȱ��ȭ��Ű��
                    enemy.SetActive(true);
                    //3.enemy�� enemyFactory ��ġ���� �߻� 
                    //���丮�� X�� ���� ���� : �ִ� 6.0����
                    enemy.transform.Translate(Random.Range(0.0f, xRange) * Time.deltaTime * Vector3.right);
                    break;
                }
            }

            passTime = 0.0f;

        }
    }



}
