using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar_MoveLeft : MonoBehaviour
{
    private float _speed = 14.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }
}
