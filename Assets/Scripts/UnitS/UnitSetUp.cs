using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSetUp : UnitState
{
    public GameObject thisGameObject;
    public override void Enter()
    {
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        thisGameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public override void Exit()
    {
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
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
