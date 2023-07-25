using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_Dark : MonoBehaviour
{
    public SpriteRenderer weather;
    public bool active = false;
    public bool isVisible = false;

    private float _time = 3.0f;
    private float _timer;
    private float _alphaValue = 0;

    private void Start()
    {
        weather.color = new Color(0f, 0f, 255f, 0f);
    }

    private void Update()
    {
        if (active == false)
        {
            _timer = 0;
        }

        if (active == true)
        {
            if (isVisible == true)
            {
                FadeIn();
            }

            if (isVisible == false)
            {
                FadeOut();
            }
        }
    }

    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
    }

    #region Fade In
    private void FadeIn()
    {
        UpdateTimer();

        if (_timer <= _time)
        {
            UpdateFadeInColor();
        }

        else
        {
            active = false;
        }
    }

    private void UpdateFadeInColor()
    {
        _alphaValue += 0.001f;
        weather.color = new Color(0f, 0f, 255f, _alphaValue);
    }
    #endregion

    #region Fade Out
    private void FadeOut()
    {
        UpdateTimer();

        if (_timer <= _time)
        {
            UpdateFadeOutColor();
        }

        else
        {
            active = false;
        }
    }

    private void UpdateFadeOutColor()
    {
        _alphaValue -= 0.001f;
        weather.color = new Color(0f, 0f, 255f, _alphaValue);
    }
    #endregion
}
