using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSetUp : UnitState
{
    public override void Enter()
    {
        Debug.Log("Unit Ready");
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }
    public override void Exit()
    {
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        Debug.Log("Selected");
    }
    void OnPressedConfirm()
    {
        if (Mathf.Abs(StateMachine.Cursor.transform.position.x - this.gameObject.transform.position.x) <= 0.7f && 
            Mathf.Abs(StateMachine.Cursor.transform.position.y - this.gameObject.transform.position.y) <= 0.7f)
        {
            StateMachine.ChangeState<UnitSelect>();
        }
    }
}
