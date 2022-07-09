using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 5;

    public GameObject explosionFactory;     //총알_폭발효과 공장
    GameObject target;

    Vector3 dir = Vector3.zero;

    private void Awake()
    {
        target = GameObject.Find("Player");
    }

    private void Start()
    {
        int RandomEnemy = Random.Range(0, 10);
        if(RandomEnemy < 3)
        {
            dir = target.transform.position - transform.position;
            dir.Normalize();

        }
        else
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {

       transform.Translate(enemySpeed * Time.deltaTime * dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //1.폭발효과 생성
        GameObject explosion = Instantiate(explosionFactory);

        //2.폭발효과 배치
        explosion.transform.position = transform.position;

        //3.만약 부딪힌게 총알이면 비활성화시키고 탄창에 넣는다
        if (collision.gameObject.name.Contains("Bullet")) //layer로 구분
        {
            collision.gameObject.SetActive(false);
        }
        else
        {   //총알이 아니라면 죽인다
            Destroy(collision.gameObject);
        }

        //Destroy(this.gameObject);       //나 _enemy
        gameObject.SetActive(false);

        //적을 잡을 때 현재점수 표시
        //1.scoremanager스트립트 오브젝트를 찾고
        //GameObject scoreManagerObj = GameObject.Find("ScoreManager");
        //2.컴포넌트 가져옴
        //ScoreManager smComponent = scoreManagerObj.GetComponent<ScoreManager>();
        //smComponent.SetScore(smComponent.SetScore() + 1);
        
        ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);

    }
}
