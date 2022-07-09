using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 5;

    public GameObject explosionFactory;     //�Ѿ�_����ȿ�� ����
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
        //1.����ȿ�� ����
        GameObject explosion = Instantiate(explosionFactory);

        //2.����ȿ�� ��ġ
        explosion.transform.position = transform.position;

        //3.���� �ε����� �Ѿ��̸� ��Ȱ��ȭ��Ű�� źâ�� �ִ´�
        if (collision.gameObject.name.Contains("Bullet")) //layer�� ����
        {
            collision.gameObject.SetActive(false);
        }
        else
        {   //�Ѿ��� �ƴ϶�� ���δ�
            Destroy(collision.gameObject);
        }

        //Destroy(this.gameObject);       //�� _enemy
        gameObject.SetActive(false);

        //���� ���� �� �������� ǥ��
        //1.scoremanager��Ʈ��Ʈ ������Ʈ�� ã��
        //GameObject scoreManagerObj = GameObject.Find("ScoreManager");
        //2.������Ʈ ������
        //ScoreManager smComponent = scoreManagerObj.GetComponent<ScoreManager>();
        //smComponent.SetScore(smComponent.SetScore() + 1);
        
        ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);

    }
}
