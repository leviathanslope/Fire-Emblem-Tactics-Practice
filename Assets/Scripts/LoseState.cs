using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseState : FEState
{
    [SerializeField] TMP_Text _loseText;
    public override void Enter()
    {
        _loseText.gameObject.SetActive(true);
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
        _loseText.gameObject.SetActive(true);
    }
}
