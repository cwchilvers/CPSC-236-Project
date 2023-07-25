using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Explode : MonoBehaviour
{
    public GameObject player;
    public GameObject explosion;

    public void Explode()
    {
        GameObject _explosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(_explosion, 5);
    }
}