using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    #region Public Variables
    public SpriteRenderer playerSprite;
    public Rigidbody playerRigidbody;
    public GameObject colliderLeft;
    public GameObject colliderRight;
    public Animator animator;
    public float moveSpeed = 5;
    public KeyCode left;
    public KeyCode right;
    #endregion

    #region Private Variables
    private Vector3 _playerVelocity;
    private float _playerSpeed;
    private bool _collisionLeft;
    private bool _collisionRight;
    #endregion

    #region Update
    private void Update()
    {
        CheckCollisions();
        Animation();
    }

    private void FixedUpdate()
    {
        MoveLeft();
        MoveRight();
    }
    #endregion

    #region Checking Collisions
    private void CheckCollisions()
    {
        _collisionLeft = colliderLeft.GetComponent<Player_CollisionBoxes>().CheckCollision();
        _collisionRight = colliderRight.GetComponent<Player_CollisionBoxes>().CheckCollision();
    }
    #endregion

    #region Move
    public void MoveLeft()
    {
        if (_collisionLeft == false && Input.GetKey(left))
        {
            AddForce(new Vector2(-1, 0));
        }
    }

    private void MoveRight()
    {
        if (_collisionRight == false && Input.GetKey(right))
        {
            AddForce(new Vector2(1, 0));
        }
    }

    public void AddForce(Vector2 _direction)
    {
        Vector2 moveAmount = CalculateMove(_direction);
        playerRigidbody.AddRelativeForce(moveAmount);
        ChangeSpriteDirection(_direction);
    }

    private Vector2 CalculateMove(Vector2 _direction)
    {
        float amountX = moveSpeed * _direction.x;
        float amountY = moveSpeed * _direction.y;
        return new Vector2(amountX, amountY);
    }

    private void ChangeSpriteDirection(Vector2 _direction)
    {
        if (_direction.x == 1)
            playerSprite.flipX = false;

        else if (_direction.x == -1)
            playerSprite.flipX = true;
    }
    #endregion

    #region Animation
    private void Animation()
    {
        _playerVelocity = playerRigidbody.velocity;
        _playerSpeed = _playerVelocity.magnitude;
        animator.SetFloat("Speed", _playerSpeed);
    }
    #endregion
}