using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressBools : MonoBehaviour
{
    public bool buttonPressed = false;

    public void Clicked()
    {
        buttonPressed = true;
    }
}
