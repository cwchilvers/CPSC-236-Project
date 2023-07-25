using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    #region Public Variables
    public Text timer;
    public AudioSource weatherAudio;
    public AudioClip weatherAlert;
    public GameObject bean;
    public GameObject sandie;
    public GameObject ninjaStarMoveLeft;
    public GameObject ninjaStarMoveRight;
    public GameObject ninjaStarMoveLeft_Fast;
    public GameObject ninjaStarMoveRight_Fast;
    public GameObject ninjaMoveLeft;
    public GameObject ninjaMoveRight;
    public GameObject weatherDark;
    public GameObject mainCode;
    public GameObject stormWarning;
    public GameObject iceWarning;
    public GameObject fog;
    public GameObject iceBackground;
    public GameObject ice1;
    public GameObject ice2;
    public GameObject ice3;
    public GameObject ice4;
    public GameObject sparkle;
    public GameObject grass;
    public Collider ground;
    public Collider branch1;
    public Collider branch2;
    public Collider branch3;
    public Collider branch4;
    public Transform Spawner_TR;
    public Transform Spawner_MR;
    public Transform Spawner_BR;
    public Transform Spawner_TL;
    public Transform Spawner_ML;
    public Transform Spawner_BL;
    public Transform Spawner_Ninja_L;
    public Transform Spawner_Ninja_R;
    public SpriteRenderer rain;
    #endregion

    #region Private Variables
    private float _time = 60f;
    private float _sparkleTime;
    private float _sparkleTimer;
    private int _spawnOnce = 0;
    private bool _isFreezing = false;
    private float _endGameTimer = 0;
    #endregion

    #region Start
    void Start()
    {
        rain.color = new Color(1f, 1f, 1f, 0f);
    }
    #endregion

    #region Update
    void Update()
    {
        UpdateTime();
        UpdateTimer();
        MainGame();
        EndGame();
        if (_isFreezing == true)
        {
            CreateSparkles();
        }
    }
    #endregion

    #region Timer
    private void UpdateTime()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
    }

    private void UpdateTimer()
    {
        timer.text = (_time).ToString("0");
    }
    #endregion

    #region Main Game
    private void MainGame()
    {
        if (timer.text.Equals("58") && _spawnOnce == 0)
        {
            Spawn_MR();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("57") && _spawnOnce == 1)
        {
            Spawn_BL();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("55") && _spawnOnce == 0)
        {
            Spawn_BR();
            Spawn_BL();
            Spawn_TR();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("53") && _spawnOnce == 1)
        {
            Spawn_BL();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("51") && _spawnOnce == 0)
        {
            Spawn_TL();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("50") && _spawnOnce == 1)
        {
            Spawn_MR();
            Spawn_BL();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("47") && _spawnOnce == 0)
        {
            Spawn_BL();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("46") && _spawnOnce == 1)
        {
            Spawn_MR();
            Spawn_TL();
            Spawn_Ninja_L();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("42") && _spawnOnce == 0)
        {
            Spawn_BR();
            Spawn_TL();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("41") && _spawnOnce == 1)
        {
            Spawn_ML();
            Spawn_TR();
            Spawn_Ninja_R();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("40") && _spawnOnce == 0)
        {
            Spawn_TL();
            Spawn_BR();
            _spawnOnce = 1;
        }

        // STORM
        if (timer.text.Equals("38") && _spawnOnce == 1)
        {
            Spawn_BL();
            Spawn_MR();
            Storm();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("36") && _spawnOnce == 0)
        {
            Spawn_MR();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("35") && _spawnOnce == 1)
        {
            Spawn_BL();
            Spawn_MR();
            Spawn_Ninja_R();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("34") && _spawnOnce == 0)
        {
            Spawn_BR();
            Spawn_BL();
            Spawn_MR();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("33") && _spawnOnce == 1)
        {
            Spawn_TL();
            Spawn_Ninja_L();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("32") && _spawnOnce == 0)
        {
            Spawn_BL();
            Spawn_TR();
            Spawn_Ninja_R();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("31") && _spawnOnce == 1)
        {
            Spawn_TL();
            Spawn_FastNinjaStar_BR();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("30") && _spawnOnce == 0)
        {
            Spawn_BR();
            Spawn_FastNinjaStar_ML();
            Spawn_MR();
            Spawn_FastNinjaStar_TR();
            _spawnOnce = 1;
        }

        // FOG
        if (timer.text.Equals("29") && _spawnOnce == 1)
        {
            Fog();
            Spawn_FastNinjaStar_TL();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("27") && _spawnOnce == 0)
        {
            Spawn_TL();
            _spawnOnce = 1;
        }


        if (timer.text.Equals("26") && _spawnOnce == 1)
        {
            Spawn_ML();
            Spawn_TL();
            Spawn_FastNinjaStar_BR();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("25") && _spawnOnce == 0)
        {
            Spawn_FastNinjaStar_TR();
            Spawn_BL();
            Spawn_TR();
            _spawnOnce = 1;
        }


        if (timer.text.Equals("23") && _spawnOnce == 1)
        {
            Spawn_MR();
            Spawn_FastNinjaStar_BL();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("22") && _spawnOnce == 0)
        {
            Spawn_BR();
            Spawn_TL();
            Spawn_FastNinjaStar_TL();
            _spawnOnce = 1;
        }


        if (timer.text.Equals("21") && _spawnOnce == 1)
        {
            Spawn_MR();
            Spawn_ML();
            _spawnOnce = 0;
        }

        // ICE
        if (timer.text.Equals("20") && _spawnOnce == 0)
        {
            Ice();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("19") && _spawnOnce == 1)
        {
            Spawn_MR();
            Spawn_FastNinjaStar_BL();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("18") && _spawnOnce == 0)
        {
            Spawn_BR();
            Spawn_FastNinjaStar_TL();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("16") && _spawnOnce == 1)
        {
            Spawn_Ninja_R();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("14") && _spawnOnce == 0)
        {
            Spawn_BR();
            Spawn_FastNinjaStar_ML();
            Spawn_MR();
            Spawn_FastNinjaStar_TR();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("12") && _spawnOnce == 1)
        {
            Spawn_BL();
            Spawn_FastNinjaStar_BR();
            Spawn_FastNinjaStar_TL();
            Spawn_Ninja_R();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("10") && _spawnOnce == 0)
        {
            Spawn_ML();
            Spawn_TR();
            Spawn_Ninja_L();
            Spawn_FastNinjaStar_TR();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("9") && _spawnOnce == 1)
        {
            Spawn_Ninja_R();
            Spawn_TL();
            Spawn_FastNinjaStar_BR();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("8") && _spawnOnce == 0)
        {
            Spawn_TR();
            Spawn_FastNinjaStar_MR();
            Spawn_ML();
            Spawn_FastNinjaStar_BL();
            Spawn_FastNinjaStar_TR();
            Spawn_Ninja_L();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("6") && _spawnOnce == 1)
        {
            Spawn_BR();
            Spawn_TL();
            Spawn_FastNinjaStar_BL();
            Spawn_ML();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("5") && _spawnOnce == 0)
        {
            Spawn_Ninja_R();
            Spawn_MR();
            Spawn_TR();
            Spawn_FastNinjaStar_TR();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("4") && _spawnOnce == 1)
        {
            Spawn_TL();
            Spawn_FastNinjaStar_ML();
            Spawn_Ninja_R();
            _spawnOnce = 0;
        }

        if (timer.text.Equals("3") && _spawnOnce == 0)
        {
            Spawn_Ninja_L();
            Spawn_FastNinjaStar_TR();
            Spawn_FastNinjaStar_BR();
            _spawnOnce = 1;
        }

        if (timer.text.Equals("2") && _spawnOnce == 1)
        {
            Spawn_ML();
            Spawn_FastNinjaStar_TL();
            Spawn_FastNinjaStar_BR();
            Spawn_BL();
            Spawn_Ninja_L();
            _spawnOnce = 0;
        }
    }
    #endregion

    #region Weather
    private void Storm()
    {
        mainCode.GetComponent<Weather_Wind>().wind = true;

        weatherDark.GetComponent<Weather_Dark>().active = true;
        weatherDark.GetComponent<Weather_Dark>().isVisible = true;

        Instantiate(stormWarning, new Vector3(0f, 0f, -1.00f), transform.rotation);
        rain.color = new Color(1f, 1f, 1f, 1f);
        weatherAudio.PlayOneShot(weatherAlert, .3f);
    }

    private void Fog()
    {
        Instantiate(fog, new Vector3(16.51f, 4.32f, -1.07f), transform.rotation);
    }

    private void Ice()
    {
        weatherAudio.PlayOneShot(weatherAlert, .3f);

        weatherDark.GetComponent<Weather_Dark>().active = true;
        weatherDark.GetComponent<Weather_Dark>().isVisible = false;

        grass.GetComponent<Weather_FadeOut>().isVisible = false;

        Instantiate(iceWarning, new Vector3(0f, 0f, -1.00f), transform.rotation);
        _isFreezing = true;
        rain.color = new Color(1f, 1f, 1f, 0f);
        mainCode.GetComponent<Weather_Wind>().wind = false;
        iceBackground.GetComponent<Weather_FadeIn>().isVisible = true;
        ice1.GetComponent<Weather_FadeIn>().isVisible = true;
        ice2.GetComponent<Weather_FadeIn>().isVisible = true;
        ice3.GetComponent<Weather_FadeIn>().isVisible = true;
        ice4.GetComponent<Weather_FadeIn>().isVisible = true;
        ground.material.dynamicFriction = 0.01f;
        branch1.material.dynamicFriction = 0.01f;
        branch2.material.dynamicFriction = 0.01f;
        branch3.material.dynamicFriction = 0.01f;
        branch4.material.dynamicFriction = 0.01f;
    }
    #endregion

    #region Sparkles
    private void CreateSparkles()
    {
        UpdateSparkleTimer();
        SelectSparkleTime();
        CheckSparkleTimer();
    }

    private void UpdateSparkleTimer()
    {
        _sparkleTimer += Time.deltaTime;
    }

    private void SelectSparkleTime()
    {
        _sparkleTime = Random.Range(.5f, 2);
    }

    private void CheckSparkleTimer()
    {
        if (_sparkleTimer >= _sparkleTime)
        {
            _sparkleTimer = 0;
            Sparkle();
        }
    }

    void Sparkle()
    {
        float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(sparkle, spawnPosition, Quaternion.identity);
    }
    #endregion

    #region Spawn Ninja Stars
    void Spawn_TR()
    {
        Instantiate(ninjaStarMoveLeft, Spawner_TR.position, transform.rotation);
    }

    void Spawn_MR()
    {
        Instantiate(ninjaStarMoveLeft, Spawner_MR.position, transform.rotation);
    }

    void Spawn_BR()
    {
        Instantiate(ninjaStarMoveLeft, Spawner_BR.position, transform.rotation);
    }

    void Spawn_TL()
    {
        Instantiate(ninjaStarMoveRight, Spawner_TL.position, transform.rotation);
    }

    void Spawn_ML()
    {
        Instantiate(ninjaStarMoveRight, Spawner_ML.position, transform.rotation);
    }

    void Spawn_BL()
    {
        Instantiate(ninjaStarMoveRight, Spawner_BL.position, transform.rotation);
    }
    #endregion

    #region Spawn Fast Ninja Stars
    void Spawn_FastNinjaStar_TR()
    {
        Instantiate(ninjaStarMoveLeft_Fast, Spawner_TR.position, transform.rotation);
    }

    void Spawn_FastNinjaStar_MR()
    {
        Instantiate(ninjaStarMoveLeft_Fast, Spawner_MR.position, transform.rotation);
    }

    void Spawn_FastNinjaStar_BR()
    {
        Instantiate(ninjaStarMoveLeft_Fast, Spawner_BR.position, transform.rotation);
    }

    void Spawn_FastNinjaStar_TL()
    {
        Instantiate(ninjaStarMoveRight_Fast, Spawner_TL.position, transform.rotation);
    }

    void Spawn_FastNinjaStar_ML()
    {
        Instantiate(ninjaStarMoveRight_Fast, Spawner_ML.position, transform.rotation);
    }

    void Spawn_FastNinjaStar_BL()
    {
        Instantiate(ninjaStarMoveRight_Fast, Spawner_BL.position, transform.rotation);
    }
    #endregion

    #region Spawn Running Ninjas
    void Spawn_Ninja_L()
    {
        Instantiate(ninjaMoveRight, Spawner_Ninja_L.position, transform.rotation);
    }

    void Spawn_Ninja_R()
    {
        Instantiate(ninjaMoveLeft, Spawner_Ninja_R.position, transform.rotation);
    }
    #endregion

    #region End Game
    private void EndGame()
    {
        if (bean.GetComponent<Player_Health>().isDead == true && sandie.GetComponent<Player_Health>().isDead == true)
        {
            WaitOneSecond();
            DetermineWinner();
        }

        if (_time <= 0)
        {
            WaitOneSecond();
            DetermineWinner();
        }

        if (bean.GetComponent<Player_Health>().isDead == true)
        {
            WaitOneSecond();
            if (_endGameTimer > 1)
                WinnerSandie();
        }

        if (sandie.GetComponent<Player_Health>().isDead == true)
        {
            WaitOneSecond();
            if (_endGameTimer > 1)
                WinnerBean();
        }
    }

    private void DetermineWinner()
    {
        if (bean.GetComponent<Player_Health>().chances > sandie.GetComponent<Player_Health>().chances)
        {            
            if (_endGameTimer > 1)
                WinnerBean();
        }

        if (bean.GetComponent<Player_Health>().chances < sandie.GetComponent<Player_Health>().chances)
        {
            if (_endGameTimer > 1)
                WinnerSandie();
        }

        if (bean.GetComponent<Player_Health>().chances == sandie.GetComponent<Player_Health>().chances)
        {
            if (bean.GetComponent<Player_Health>().health > sandie.GetComponent<Player_Health>().health)
            {
                if (_endGameTimer > 1)
                    WinnerBean();
            }

            if (bean.GetComponent<Player_Health>().health < sandie.GetComponent<Player_Health>().health)
            {
                if (_endGameTimer > 1)
                    WinnerSandie();
            }

            if (bean.GetComponent<Player_Health>().health == sandie.GetComponent<Player_Health>().health)
            {
                if (_endGameTimer > 1)
                    Draw();
            }
        }
    }

    private void WinnerBean()
    {

        SceneManager.LoadScene("WinnerBean");
    }

    private void WinnerSandie()
    {
        SceneManager.LoadScene("WinnerSandie");
    }

    private void Draw()
    {
        SceneManager.LoadScene("Draw");
    }

    private void WaitOneSecond()
    {
        if (_endGameTimer <= 2)
        {
            UpdateEndGameTimer();
        }
    }

    private void UpdateEndGameTimer()
    {
        _endGameTimer += Time.deltaTime;
    }
    #endregion
}
