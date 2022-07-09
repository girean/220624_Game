using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;   //총알공장
    public float bulletSpeed = 10.0f;  //총알속도

    public GameObject firePosition;    //총구

    public int bulletSize = 10;        //탄창에 넣을 총알개수
    GameObject[] bulletObjectPool;     //탄창

    private void Awake()
    {
        //1.탄창을 만들고 
        bulletObjectPool = new GameObject[bulletSize];

    }

    private void Start()
    {
        //2.반복해서 탄청크기만큼 총알을 만들어 채우고
        for(int i = 0; i<bulletObjectPool.Length; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            //3.총알을 탄창에 넣는다
            bulletObjectPool[i] = bullet;
            //4.비활성화
            bullet.SetActive(false);
        }

    }


    void Update()
    {

    }


    //1.스페이스바 누르면
    void OnFire(InputValue value)
    {

        if (value != null)
        {

            for(int i=0; i<bulletObjectPool.Length; i++)
            {

                //탄창의 총알이 비활성화되어 있다면
                GameObject bullet = bulletObjectPool[i];
                if (bullet.activeSelf == false)
                {
                    //총알 활성화
                    bullet.SetActive(true);

                    //3.총알이 총구 앞에서 위쪽으로 방향 전환
                    bullet.transform.position = firePosition.transform.position;
                    bullet.transform.rotation = firePosition.transform.rotation;

                    //찾았다면 중단
                    break;

                }

            }

        }
    }





}
