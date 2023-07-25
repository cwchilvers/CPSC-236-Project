using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Flicker : MonoBehaviour
{
    public SpriteRenderer player;
    public bool isFlickering = true;

    private int _flickerState = 0;
    private int _flickerTime = 80;

    private void FixedUpdate()
    {
        CheckIfFlickering();
    }

    private void CheckIfFlickering()
    {
        if (isFlickering == true)
        {
            SetFlickerState();
            Flicker();
        }

        else
        {
            ResetAlpha();
        }
    }

    public void SetFlickerState()
    {
        if (_flickerState >= 0)
        {
            _flickerState += 1;
        }

        if (_flickerState == 8)
        {
            _flickerState = 0;
        }

        if (_flickerTime > 0)
        {
            _flickerTime -= 1;
        }

        if (_flickerTime == 0)
        {
            isFlickering = false;
            _flickerTime = 80;
        }
    }

    public void Flicker()
    {
        if (_flickerState >= 0 && _flickerState < 4)
        {
            player.color = new Color(1f, 1f, 1f, 1f);
        }

        if (_flickerState >= 4)
        {
            player.color = new Color(1f, 1f, 1f, .5f);
        }
    }

    public void ResetAlpha()
    {
        player.color = new Color(1f, 1f, 1f, 1f);
    }
}
