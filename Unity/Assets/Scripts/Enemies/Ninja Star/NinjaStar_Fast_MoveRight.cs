using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar_Fast_MoveRight : MonoBehaviour
{
    private float _speed = 24.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}
