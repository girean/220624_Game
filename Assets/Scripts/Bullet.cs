using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5;


    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.up;
    }
}
