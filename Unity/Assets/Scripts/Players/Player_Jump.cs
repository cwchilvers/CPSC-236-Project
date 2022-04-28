using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    #region Public Variables
    public Rigidbody playerRigidbody;
    public AudioSource playerAudio;
    public AudioClip playerJump;
    public GameObject colliderBottom;
    public GameObject player;
    public Animator animator;
    public KeyCode jumpKey;
    public float buttonTime = 0.3f;
    public float jumpAmount = 20f;
    #endregion

    #region Private Variables
    private float _jumpTime;
    private bool _isJumping;
    private bool _isGrounded;
    #endregion

    #region Update
    void Update()
    {
        CheckIfGrounded();
        SetAnimation();
        Jump();
    }
    #endregion

    #region Check If Grounded
    private void CheckIfGrounded()
    {
        _isGrounded = colliderBottom.GetComponent<Player_CollisionBoxes>().CheckCollision();
    }
    #endregion

    #region Jump
    private void Jump()
    {
        if (_isGrounded == true && Input.GetKeyDown(jumpKey))
        {
            _isJumping = true;
            _jumpTime = 0;
            _isGrounded = false;
            if (player.GetComponent<Player_Health>().isWaitingForRespawn == false)
            {
                playerAudio.PlayOneShot(playerJump, .3f);
            }
        }

        if (_isJumping)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpAmount);
            _jumpTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(jumpKey) | _jumpTime > buttonTime)
        {
            _isJumping = false;
        }
    }
    #endregion

    #region Animation
    private void SetAnimation()
    {
        if (_isGrounded == true)
        {
            animator.SetBool("Grounded", true);
        }

        if (_isGrounded == false)
        {
            animator.SetBool("Grounded", false);
        }
    }
    #endregion
}