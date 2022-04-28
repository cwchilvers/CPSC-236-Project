using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_MoveRight : MonoBehaviour
{
    private float _speedRight = 25.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speedRight);
    }
}
