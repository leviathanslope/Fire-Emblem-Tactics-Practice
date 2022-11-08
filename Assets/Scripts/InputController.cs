using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public event Action PressedConfirm = delegate { };
    public event Action PressedCancel = delegate { };
    public event Action PressedLeft = delegate { };
    public event Action PressedRight = delegate { };
    public event Action PressedUp = delegate { };
    public event Action PressedDown = delegate { };

    private void Update()
    {
        DetectConfirm();
        DetectCancel();
        DetectLeft();
        DetectRight();
        DetectUp();
        DetectDown();
    }

    private void DetectConfirm()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PressedConfirm?.Invoke();
        }
    }

    private void DetectCancel()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PressedCancel?.Invoke();
        }
    }

    private void DetectLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PressedLeft?.Invoke();
        }
    }

    private void DetectRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PressedRight?.Invoke();
        }
    }

    private void DetectUp()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PressedUp?.Invoke();
        }
    }

    private void DetectDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PressedDown?.Invoke();
        }
    }
}
