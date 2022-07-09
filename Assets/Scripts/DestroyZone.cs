using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        //���� �ε����� �Ѿ��̸� ��Ȱ��ȭ��Ű�� źâ�� �ִ´�
        if (collision.gameObject.name.Contains("Bullet")|| collision.gameObject.name.Contains("Enemy")) //layer�� ����
        {
            collision.gameObject.SetActive(false);
        }
        else
        {   //�Ѿ��� �ƴ϶�� ���δ�
            Destroy(collision.gameObject);
        }

    }

}
