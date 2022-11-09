using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinState : FEState
{
    [SerializeField] TMP_Text _winText;
    public override void Enter()
    {
        _winText.gameObject.SetActive(true);
    }

    public override void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public override void Exit()
    {
        _winText.gameObject.SetActive(true);
    }
}
