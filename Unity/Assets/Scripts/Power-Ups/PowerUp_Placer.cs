using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Placer : MonoBehaviour
{
    public Transform    spawner_1;
    public Transform    spawner_2;
    public Transform    spawner_3;
    public Transform    spawner_4;
    public Transform    spawner_5;
    public Transform    spawner_6;
    public GameObject   fish;
    public GameObject   bone;

    private GameObject  _powerUp;
    private Transform   _location;
    private int         _numPowerUp;
    private int         _numLocation;
    private float       _time;
    private float       _timer;

    void Start()
    {
        SelectTime();
    }

    void FixedUpdate()
    {
        UpdateTimer();
        CheckTimer();
    }

    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
    }

    private void CheckTimer()
    {
        if (_timer >= _time)
        {
            
            SelectTime();
            SelectPowerUp();
            SelectLocation();
            SpawnPowerUp();
            ResetTimer();
        }
    }

    private void SelectTime()
    {
        _time = Random.Range(4, 8);
    }

    private void SelectPowerUp()
    {
        _numPowerUp = Random.Range(1, 4);

        if (_numPowerUp >= 1 && _numPowerUp <= 2)
        {
            _powerUp = fish;
        }

        if (_numPowerUp >= 3 && _numPowerUp <= 4)
        {
            _powerUp = bone;
        }
    }

    private void SelectLocation()
    {
        _numLocation = Random.Range(1, 6);

        if (_numLocation == 1)
        {
            _location = spawner_1;
        }

        if (_numLocation == 2)
        {
            _location = spawner_2;
        }

        if (_numLocation == 3)
        {
            _location = spawner_3;
        }

        if (_numLocation == 4)
        {
            _location = spawner_4;
        }

        if (_numLocation == 5)
        {
            _location = spawner_5;
        }

        if (_numLocation == 6)
        {
            _location = spawner_6;
        }
    }

    private void SpawnPowerUp()
    {
        Instantiate(_powerUp, _location.position, transform.rotation);
    }

    private void ResetTimer()
    {
        _timer = 0;
    }
}
