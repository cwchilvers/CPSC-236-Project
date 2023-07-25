using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar_MoveRight : MonoBehaviour
{
    private float _speed = 14.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}
