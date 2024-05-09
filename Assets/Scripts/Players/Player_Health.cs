using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    #region Public Variables
    public GameObject player;
    public AudioSource playerAudio;
    public AudioClip playerKilled;
    public AudioClip playerHurt;
    public AudioClip healthUp;
    public SphereCollider playerCollider;
    public Image playerIcon;
    public Image playerHealth;
    public Text playerChances;
    public Transform playerWaitingBox;
    public Sprite playerDead;
    public Sprite health3;
    public Sprite health2;
    public Sprite health1;
    public Sprite health0;
    public bool isWaitingForRespawn = false;
    public GameObject addHP;
    public GameObject subHP;
    public string powerUp;
    public bool isDead = false;
    public int health = 3;
    public int chances = 3;
    #endregion

    #region Private Variables
    private bool _isFlickering = true;

    private float _timer = 0;
    private string _chances_3 = "X3";
    private string _chances_2 = "X2";
    private string _chances_1 = "X1";
    private string _chances_0 = "X0";
    #endregion

    #region Update
    private void Update()
    {
        CheckFlicker();
        CheckWaitingForRespawn();
        UpdateHealthbar();
        UpdateChances();
    }
    #endregion

    #region Collision
    void OnTriggerEnter(Collider _other)
    {
        CheckEnemy(_other);
        CheckPowerUp(_other);
    }
    #endregion

    #region Checking Methods
    private void CheckEnemy(Collider _other)
    {
        if (_other.gameObject.tag == "Enemy")
        {
            if (_isFlickering == false && health > 0)
            {
                health -= 1;
                _isFlickering = true;
                player.GetComponent<Player_Flicker>().isFlickering = true;
                Instantiate(subHP, player.transform.position, transform.rotation);
                if (health >= 1)
                {
                    playerAudio.PlayOneShot(playerHurt, 1);
                    player.GetComponent<Player_Move>().moveSpeed -= 0.5f;
                }
            }
        }
    }

    private void CheckPowerUp(Collider _other)
    {
        if (_other.gameObject.tag == powerUp)
        {
            if (health < 3)
            {
                health += 1;
                Destroy(_other.gameObject);
                Instantiate(addHP, player.transform.position, transform.rotation);
                playerAudio.PlayOneShot(healthUp, .3f);
            }
        }
    }

    private void CheckFlicker()
    {
        _isFlickering = player.GetComponent<Player_Flicker>().isFlickering;
    }

    private void CheckWaitingForRespawn()
    {
        if (isWaitingForRespawn == true)
        {
            WaitForRespawn();
        }
    }
    #endregion Checking Methods

    #region Updating Methods
    private void UpdateHealthbar()
    {
        if (health == 3)
        {
            playerHealth.sprite = health3;
        }
        if (health == 2)
        {
            playerHealth.sprite = health2;
        }
        if (health == 1)
        {
            playerHealth.sprite = health1;
        }
        if (health == 0)
        {
            if (isWaitingForRespawn == false)
            {
                playerHealth.sprite = health0;
                KillPlayer();
            }
        }
    }


    private void UpdateChances()
    {
        if (chances == 3)
        {
            playerChances.text = _chances_3;
        }
        if (chances == 2)
        {
            playerChances.text = _chances_2;
        }
        if (chances == 1)
        {
            playerChances.text = _chances_1;
        }
        if (chances == 0)
        {
            playerChances.text = _chances_0;
            playerIcon.sprite = playerDead;
            playerHealth.sprite = health0;
            isDead = true;
            HidePlayer();
        }
    }
    #endregion

    #region Kill Player
    private void KillPlayer()
    {
        Explode();
        playerAudio.PlayOneShot(playerKilled, 1);
        HidePlayer();
        SubtractChances();
        SetRespawnTimer();
        isWaitingForRespawn = true;
    }

    private void Explode()
    {
        player.GetComponent<Player_Explode>().Explode();
    }

    private void HidePlayer()
    {
        player.transform.position = playerWaitingBox.position;
    }

    private void SubtractChances()
    {
        chances -= 1;
    }

    private void SetRespawnTimer()
    {
        _timer = 0;
    }
    #endregion

    #region Respawn
    private void WaitForRespawn()
    {
        UpdateRespawnTimer();
        CheckRespawnTimer();
    }

    private void UpdateRespawnTimer()
    {
        if (_timer <= 2f)
        {
            _timer += Time.deltaTime;
        }
    }

    private void CheckRespawnTimer()
    {
        if (_timer > 2f)
        {
            ResetVariables();
            Respawn();
        }
    }
    private void ResetVariables()
    {
        _timer = 0;
        health = 3;
        isWaitingForRespawn = false;
        player.GetComponent<Player_Move>().moveSpeed = 5;
    }

    private void Respawn()
    {
        player.transform.position = new Vector3(-3.23f, 2.75f, 0.199998f);
    }
    #endregion
}
