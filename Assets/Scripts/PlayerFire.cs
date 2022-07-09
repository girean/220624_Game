using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;   //�Ѿ˰���
    public float bulletSpeed = 10.0f;  //�Ѿ˼ӵ�

    public GameObject firePosition;    //�ѱ�

    public int bulletSize = 10;        //źâ�� ���� �Ѿ˰���
    GameObject[] bulletObjectPool;     //źâ

    private void Awake()
    {
        //1.źâ�� ����� 
        bulletObjectPool = new GameObject[bulletSize];

    }

    private void Start()
    {
        //2.�ݺ��ؼ� źûũ�⸸ŭ �Ѿ��� ����� ä���
        for(int i = 0; i<bulletObjectPool.Length; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            //3.�Ѿ��� źâ�� �ִ´�
            bulletObjectPool[i] = bullet;
            //4.��Ȱ��ȭ
            bullet.SetActive(false);
        }

    }


    void Update()
    {

    }


    //1.�����̽��� ������
    void OnFire(InputValue value)
    {

        if (value != null)
        {

            for(int i=0; i<bulletObjectPool.Length; i++)
            {

                //źâ�� �Ѿ��� ��Ȱ��ȭ�Ǿ� �ִٸ�
                GameObject bullet = bulletObjectPool[i];
                if (bullet.activeSelf == false)
                {
                    //�Ѿ� Ȱ��ȭ
                    bullet.SetActive(true);

                    //3.�Ѿ��� �ѱ� �տ��� �������� ���� ��ȯ
                    bullet.transform.position = firePosition.transform.position;
                    bullet.transform.rotation = firePosition.transform.rotation;

                    //ã�Ҵٸ� �ߴ�
                    break;

                }

            }

        }
    }





}
