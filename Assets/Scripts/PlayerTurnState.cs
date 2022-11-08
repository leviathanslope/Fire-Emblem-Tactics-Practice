using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurnState : FEState
{

    public int _units = 5;
    public int _unitsLeft = 5;
    public int _turns = 0;
    
    public override void Enter()
    {
        _turns++;
        _unitsLeft = _units;
        Debug.Log("Player Turn: ...Entering");
    }

    public override void Tick()
    {
        if (_unitsLeft == 0)
        {
            StateMachine.ChangeState<EnemyTurnState>();
        }
    }

    public override void Exit()
    {
        _turns++;
        Debug.Log("Player Turn: Exiting...");
    }
}
