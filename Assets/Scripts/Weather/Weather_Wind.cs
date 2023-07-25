using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_Wind : MonoBehaviour
{
    public Rigidbody P1_Rigidbody;
    public Rigidbody P2_Rigidbody;
    public bool wind = false;

    void FixedUpdate()
    {
        if (wind == true)
        {
            AddWind();
        }
    }

    public void AddWind()
    {
        P1_Rigidbody.AddForce(Vector3.left * 2);
        P2_Rigidbody.AddForce(Vector3.left * 2);
    }
}
