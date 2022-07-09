using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 0.2f;    //배경 속도
    public Material bgMaterial;

    
    private void Update()
    {
        //배경이 스크롤 시키고 싶다
        //1. 방향
        Vector2 dir = Vector2.up;

        //2. 스크롤 된다
        bgMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;


    }


}
