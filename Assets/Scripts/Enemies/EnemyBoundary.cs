using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundary : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

}