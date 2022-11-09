using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindUnit : ICommand
{
    [SerializeField] GameObject gameObject;
    [SerializeField] FESM fesm;
    public void Execute()
    {
        EnemyStats stats = gameObject.GetComponent<EnemyStats>();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach (GameObject go in gos)
        {
            if (Mathf.Abs(go.transform.position.x -
            gameObject.transform.position.x) <= (stats.range * 1f + (stats.movement * 1f)) && Mathf.Abs(go.transform.position.y - gameObject.transform.position.y)
            <= (stats.range * 1f + (stats.movement * 1f)))
            {
                Transform unitPos = go.transform;
                while (stats.movement > 0)
                {
                    float movement = 5;
                    if (Mathf.Abs(unitPos.position.x - gameObject.transform.position.x) > (stats.range * 1f))
                    {
                        if (unitPos.position.x < 0)
                        {
                            gameObject.transform.Translate(0.99f, 0, 0);
                            movement--;
                        }
                        else
                        {
                            gameObject.transform.Translate(-0.99f, 0, 0);
                            movement--;
                        }
                        if (unitPos.position.y < 0)
                        {
                            gameObject.transform.Translate(0, 0.99f, 0);
                            movement--;
                        }
                        else
                        {
                            gameObject.transform.Translate(0, -0.99f, 0);
                            movement--;
                        }
                    }
                }

                if (Mathf.Abs(go.transform.position.x - gameObject.transform.position.x) <= (stats.range * 1f) && 
                    Mathf.Abs(go.transform.position.y - gameObject.transform.position.y) <= (stats.range * 1f))
                {
                    go.GetComponent<UnitStats>().health -= stats.attack;
                    if (go.GetComponent<UnitStats>().health <= 0)
                    {
                        fesm.GetComponent<PlayerTurnState>()._units--;
                        go.SetActive(false);
                    }
                    if (go.GetComponent<UnitStats>().health > 0 && Mathf.Abs(go.transform.position.x - gameObject.transform.position.x) <=
                    (go.GetComponent<UnitStats>().range * 1f) && Mathf.Abs(go.transform.position.y - gameObject.transform.position.y) <= (go.GetComponent<UnitStats>().range * 1f))
                    {
                        stats.health -= go.GetComponent<UnitStats>().attack;
                        if (stats.health <= 0)
                        {
                            fesm.GetComponent<EnemyTurnState>()._enemyUnits--;
                            fesm.GetComponent<EnemyTurnState>()._enemyUnitsLeft--;
                            gameObject.transform.parent.gameObject.SetActive(false);
                        }
                    }
                }
                return;
            }
        }
    }

    public void Undo()
    {

    }
}
