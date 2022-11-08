using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpState : FEState
{
    [SerializeField] int _startingEnemyUnits = 5;
    [SerializeField] int _startingPlayerUnits = 4;

    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        Debug.Log("Creating " + _startingPlayerUnits + " for player");
        Debug.Log("Creating " + _startingEnemyUnits + " to fight");
        _activated = false;
    }

    public override void Tick()
    {
        if (_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnState>();
        }
    }

    public override void Exit()
    {
        _activated = false;
        Debug.Log("Setup: Exiting...");
    }
}
