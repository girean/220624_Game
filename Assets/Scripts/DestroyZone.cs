using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        //만약 부딪힌게 총알이면 비활성화시키고 탄창에 넣는다
        if (collision.gameObject.name.Contains("Bullet")|| collision.gameObject.name.Contains("Enemy")) //layer로 구분
        {
            collision.gameObject.SetActive(false);
        }
        else
        {   //총알이 아니라면 죽인다
            Destroy(collision.gameObject);
        }

    }

}
