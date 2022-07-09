using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;  //벡터의 크기
    private Vector3 dir = Vector3.zero; //벡터 방향
    private float movementVectorX = 0;
    private float movementVectorY = 0;


    // Update is called once per frame
    void Update()
    {
        //inputManager
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //print("h : " + h +"v: " + v);

        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        //Vector3 dir = new Vector3(h, v, 0); //벡터의 방향
        //transform.Translate(speed * Time.deltaTime * dir);

        //P = P0+vt
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        
        dir = new Vector3(movementVectorX, movementVectorY, 0.0f);
        transform.position += speed * Time.deltaTime * dir;

    }

    //1. 키를 누르는 방향으로 플레이어가 움직인다
    //void OnMove(InputAction.CallbackContext context)
    private void OnMove(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();  //InputAction.CallbackContext context -> context.ReadValue와 차이?
        

        //Debug.Log(movementVector);

        movementVectorX = movementVector.x;
        movementVectorY = movementVector.y;

    }
 

}
