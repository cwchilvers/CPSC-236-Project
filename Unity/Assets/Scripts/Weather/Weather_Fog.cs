using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_Fog : MonoBehaviour
{
    public SpriteRenderer fog;

    private float _time = 3.0f;
    private float _timer;
    private float _alphaValue = 0;

    void Start()
    {
        fog.color = new Color(1f, 1f, 1f, 0f);
    }

    void FixedUpdate()
    {
        if (_timer <= _time)
        {
            UpdateTimer();
            UpdateColor();
        }

        transform.Translate(Vector3.left * Time.deltaTime * 0.5f);
    }

    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
    }

    private void UpdateColor()
    {
        _alphaValue += 0.004f;
        fog.color = new Color(1f, 1f, 1f, _alphaValue);
    }
}
