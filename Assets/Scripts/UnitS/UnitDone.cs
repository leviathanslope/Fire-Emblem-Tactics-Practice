using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDone : UnitState
{
    [SerializeField] FESM fesm;
    int currentTurn;
    public GameObject unit;
    public override void Enter()
    {
        StateMachine.Cursor.SetActive(true);
        Debug.Log("Waiting.");
        fesm.GetComponent<PlayerTurnState>()._unitsLeft--;
        currentTurn = fesm.GetComponent<PlayerTurnState>()._turns;
        StateMachine.Stats.selected = false;
        unit.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void Tick()
    {
        if (fesm.GetComponent<PlayerTurnState>()._turns > currentTurn)
        {
            currentTurn = fesm.GetComponent<PlayerTurnState>()._turns;
            StateMachine.ChangeState<UnitSetUp>();
        }
    }

    public override void Exit()
    {
    }
}
