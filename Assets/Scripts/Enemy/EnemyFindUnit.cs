using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindUnit : MonoBehaviour
{
    [SerializeField] GameObject gameObjectt;
    [SerializeField] FESM fesm;
    GameObject[] gos;
    [SerializeField] int select = -1;

    public void Start()
    {
        gos = GameObject.FindGameObjectsWithTag("PlayerUnit");
    }
    public void Execute()
    {
        EnemyStats stats = gameObjectt.GetComponent<EnemyStats>();
        for (var i = 0; i < gos.Length; i++)
        {
            if (Mathf.Abs(gos[i].transform.position.x -
            gameObjectt.transform.position.x) <= (stats.range * 1f + (stats.movement * 1f)) && Mathf.Abs(gos[i].transform.position.y - gameObjectt.transform.position.y)
            <= (stats.range * 1f + (stats.movement * 1f)))
            {
                select = i;
                /*Go();*/
                break;
            }
        }
    }

    public void Go()
    {
        EnemyStats stats = gameObjectt.GetComponent<EnemyStats>();
        if (select <= -1)
        {
            return;
        }
        if (Mathf.Abs(gos[select].transform.position.x -
            gameObjectt.transform.position.x) <= (stats.range * 1f + (stats.movement * 1f)) && Mathf.Abs(gos[select].transform.position.y - gameObjectt.transform.position.y)
            <= (stats.range * 1f + (stats.movement * 1f)))
        {
            Transform unitPos = gos[select].transform;
            while (stats.movement > 0)
            {
                float movement = 5;
                if (Mathf.Abs(unitPos.position.x - gameObjectt.transform.position.x) > (stats.range * 1f))
                {
                    if (unitPos.position.x < 0)
                    {
                        gameObjectt.transform.Translate(0.99f, 0, 0);
                        movement--;
                    }
                    else
                    {
                        gameObjectt.transform.Translate(-0.99f, 0, 0);
                        movement--;
                    }
                    if (unitPos.position.y < 0)
                    {
                        gameObjectt.transform.Translate(0, 0.99f, 0);
                        movement--;
                    }
                    else
                    {
                        gameObjectt.transform.Translate(0, -0.99f, 0);
                        movement--;
                    }
                }
            }

            if (Mathf.Abs(gos[select].transform.position.x - gameObjectt.transform.position.x) <= (stats.range * 1f) &&
                Mathf.Abs(gos[select].transform.position.y - gameObjectt.transform.position.y) <= (stats.range * 1f))
            {
                gos[select].GetComponent<UnitStats>().health -= stats.attack;
                if (gos[select].GetComponent<UnitStats>().health <= 0)
                {
                    fesm.GetComponent<PlayerTurnState>()._units--;
                    gos[select].SetActive(false);
                }
                if (gos[select].GetComponent<UnitStats>().health > 0 && Mathf.Abs(gos[select].transform.position.x - gameObjectt.transform.position.x) <=
                (gos[select].GetComponent<UnitStats>().range * 1f) && Mathf.Abs(gos[select].transform.position.y - gameObjectt.transform.position.y) <= (gos[select].GetComponent<UnitStats>().range * 1f))
                {
                    stats.health -= gos[select].GetComponent<UnitStats>().attack;
                    if (stats.health <= 0)
                    {
                        fesm.GetComponent<EnemyTurnState>()._enemyUnits--;
                        fesm.GetComponent<EnemyTurnState>()._enemyUnitsLeft--;
                        gameObject.transform.parent.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
