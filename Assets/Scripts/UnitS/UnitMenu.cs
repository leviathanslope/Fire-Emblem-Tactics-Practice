using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UnitMenu : UnitState
{
    [SerializeField] GameObject _unitUI;
    [SerializeField] Button _attack;
    [SerializeField] Button _wait;
    public override void Enter()
    {
        Debug.Log("Menu to Attack or Cancel");
        _unitUI.SetActive(true);
        _attack.Select();
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedCancel += OnPressedCancel;
    }

    public override void Exit()
    {
        Debug.Log("Go back to movement or wait or attack");
        _unitUI.SetActive(false);
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedCancel -= OnPressedCancel;
    }

    void OnPressedConfirm()
    {
        if (_wait.GetComponent<ButtonPressBools>().buttonPressed)
        {
            Debug.Log("Waiting.");
            _wait.GetComponent<ButtonPressBools>().buttonPressed = false;
            StateMachine.ChangeState<UnitDone>();
        }
        else if (_attack.GetComponent<ButtonPressBools>().buttonPressed)
        {
            Debug.Log("Attacking.");
            _attack.GetComponent<ButtonPressBools>().buttonPressed = false;
            StateMachine.Cursor.SetActive(true);
            StateMachine.ChangeState<UnitFindEnemy>();

        }
    }

    void OnPressedCancel()
    {
        Debug.Log("Lol bye");
        StateMachine.ChangeState<UnitSelect>();
    }
}
