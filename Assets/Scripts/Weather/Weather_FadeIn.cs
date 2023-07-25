using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_FadeIn : MonoBehaviour
{
    public SpriteRenderer weather;
    public bool isVisible = false;

    private float _time = 3.0f;
    private float _timer;
    private float _alphaValue = 0;

    void Start()
    {
        weather.color = new Color(1f, 1f, 1f, 0f);
    }

    void FixedUpdate()
    {
        if (isVisible == true)
        {
            if (_timer <= _time)
            {
                UpdateTimer();
                UpdateColor();
            }
        }
    }

    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
    }

    private void UpdateColor()
    {
        _alphaValue += 0.006f;
        weather.color = new Color(1f, 1f, 1f, _alphaValue);
    }
}
