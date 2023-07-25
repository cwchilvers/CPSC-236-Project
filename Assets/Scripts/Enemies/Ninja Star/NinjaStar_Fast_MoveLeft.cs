using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar_Fast_MoveLeft : MonoBehaviour
{
    private float _speed = 24.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }
}
