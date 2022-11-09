using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnState : FEState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    public int _enemyUnits = 5;
    public int _enemyUnitsLeft = 5;

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        _enemyUnitsLeft = _enemyUnits;
        Debug.Log("Enemy Turn: ...Entering");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exiting...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        EnemyTurnEnded?.Invoke();
        StateMachine.ChangeState<PlayerTurnState>();
    }
}
