using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;  //������ ũ��
    private Vector3 dir = Vector3.zero; //���� ����
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
        //Vector3 dir = new Vector3(h, v, 0); //������ ����
        //transform.Translate(speed * Time.deltaTime * dir);

        //P = P0+vt
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        
        dir = new Vector3(movementVectorX, movementVectorY, 0.0f);
        transform.position += speed * Time.deltaTime * dir;

    }

    //1. Ű�� ������ �������� �÷��̾ �����δ�
    //void OnMove(InputAction.CallbackContext context)
    private void OnMove(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();  //InputAction.CallbackContext context -> context.ReadValue�� ����?
        

        //Debug.Log(movementVector);

        movementVectorX = movementVector.x;
        movementVectorY = movementVector.y;

    }
 

}
