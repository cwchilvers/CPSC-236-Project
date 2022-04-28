using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_FadeOut : MonoBehaviour
{
    public SpriteRenderer weather;
    public bool isVisible = true;

    private float _time = 5.0f;
    private float _timer = 0;
    private float _alphaValue = 1;

    void Start()
    {
        weather.color = new Color(1f, 1f, 1f, 1f);
    }

    void FixedUpdate()
    {
        if (isVisible == false)
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
        _alphaValue -= 0.005f;
        weather.color = new Color(1f, 1f, 1f, _alphaValue);
    }
}
