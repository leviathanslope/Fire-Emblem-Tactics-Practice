using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFindEnemy : UnitState
{
    [SerializeField] FESM fesm;
    [SerializeField] AudioClip _deathSound;
    public override void Enter()
    {
        Debug.Log("Waiting.");
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedCancel += OnPressedCancel;
    }

    public override void Exit()
    {
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedCancel -= OnPressedCancel;
        Debug.Log("Whee");
    }

    void OnPressedConfirm()
    {
        UnitStats stats = this.gameObject.transform.parent.GetComponent<UnitStats>();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in gos)
        {
            if (Mathf.Abs(StateMachine.Cursor.transform.position.x - go.transform.position.x) <= (0.7f) &&
            Mathf.Abs(StateMachine.Cursor.transform.position.y - go.transform.position.y) <= (0.7f) && Mathf.Abs(go.transform.position.x - 
            this.gameObject.transform.position.x) <= (stats.range * 1f) && Mathf.Abs(go.transform.position.y - this.gameObject.transform.position.y)
            <= (stats.range * 1f))
            {
                EnemyStats enemyStats = go.GetComponent<EnemyStats>();
                enemyStats.health -= stats.attack;
                if (enemyStats.health <= 0)
                {
                    AudioHelper.PlayClip2D(_deathSound, 1f);
                    fesm.GetComponent<EnemyTurnState>()._enemyUnits--;
                    go.SetActive(false);
                }
                if (enemyStats.health > 0 && Mathf.Abs(go.transform.position.x -this.gameObject.transform.position.x) <= 
                    (enemyStats.range * 1f) && Mathf.Abs(go.transform.position.y - this.gameObject.transform.position.y) <= (enemyStats.range * 1f))
                {
                    stats.health -= enemyStats.attack;
                    if (stats.health <= 0)
                    {
                        AudioHelper.PlayClip2D(_deathSound, 1f);
                        fesm.GetComponent<PlayerTurnState>()._units--;
                        fesm.GetComponent<PlayerTurnState>()._unitsLeft--;
                        this.gameObject.transform.parent.gameObject.SetActive(false);
                    }
                }
                StateMachine.ChangeState<UnitDone>();
                return;
            }
        }
    }

    void OnPressedCancel()
    {
        StateMachine.Cursor.SetActive(false);
        StateMachine.ChangeState<UnitMenu>();
    }
}
