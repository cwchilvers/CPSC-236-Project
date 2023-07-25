using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CollisionBoxes : MonoBehaviour
{
    public BoxCollider boxCollider;

    private bool _collision;

    public bool CheckCollision()
    {
        return _collision;
    }

    void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "Ground")
        {
            _collision = true;
        }
    }

    void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.tag == "Ground")
        {
            _collision = false;
        }
    }
}
