using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Text : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 3);
    }
}
