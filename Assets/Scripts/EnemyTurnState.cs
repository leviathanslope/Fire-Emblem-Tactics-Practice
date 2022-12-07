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
    public GameObject[] gos;

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        _enemyUnitsLeft = _enemyUnits;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        /*if (gos.Length > 0)
        {
            for (var i = 0; i < gos.Length; i++)
            {
                gos[i] = null;
            }
        }*/
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
        foreach (GameObject go in gos)
        {
            go.GetComponent<EnemyFindUnit>().Execute();
            Debug.Log("Enemy thinking...");
            yield return new WaitForSeconds(pauseDuration);
        }
        Debug.Log("Enemy performs action");
        EnemyTurnEnded?.Invoke();
        StateMachine.ChangeState<PlayerTurnState>();
    }
}
