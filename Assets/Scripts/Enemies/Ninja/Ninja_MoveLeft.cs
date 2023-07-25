using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_MoveLeft : MonoBehaviour
{
    private float _speedRight = 25.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speedRight);
    }
}
