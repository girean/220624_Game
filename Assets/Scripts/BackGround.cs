using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 0.2f;    //��� �ӵ�
    public Material bgMaterial;

    
    private void Update()
    {
        //����� ��ũ�� ��Ű�� �ʹ�
        //1. ����
        Vector2 dir = Vector2.up;

        //2. ��ũ�� �ȴ�
        bgMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;


    }


}
