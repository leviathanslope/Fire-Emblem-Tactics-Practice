using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFindUnit : MonoBehaviour
{
    [SerializeField] GameObject gameObjectt;
    [SerializeField] FESM fesm;
    public GameObject[] gos;
    public GameObject closest = null;
    public float distance = Mathf.Infinity;
    [SerializeField] int select = -1;
    [SerializeField] AudioClip _deathSound;

    public void Start()
    {
        gos = GameObject.FindGameObjectsWithTag("PlayerUnit");
    }
    public void Execute()
    {
        gameObjectt.GetComponent<SpriteRenderer>().color = Color.red;
        int i = 0;
        EnemyStats stats = gameObjectt.GetComponent<EnemyStats>();
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - gameObjectt.transform.position;
            float curDistance = diff.sqrMagnitude;
            i++;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                select = i;
            }
        }
        Debug.Log(closest);
        Go();
    }

    public void Go()
    {
        gameObjectt.GetComponent<SpriteRenderer>().color = Color.gray;
        EnemyStats stats = gameObjectt.GetComponent<EnemyStats>();
        if (select == -1)
        {
            return;
        }
        else
        {
            if (Mathf.Abs(gos[select].transform.position.x -
            gameObjectt.transform.position.x) <= (stats.range * 1f + (stats.movement * 1f)) && Mathf.Abs(gos[select].transform.position.y - gameObjectt.transform.position.y)
            <= (stats.range * 1f + (stats.movement * 1f)))
            {
                Transform unitPos = gos[select].transform;

                if (Mathf.Abs(gos[select].transform.position.x - gameObjectt.transform.position.x) <= (stats.range * 1f) &&
                    Mathf.Abs(gos[select].transform.position.y - gameObjectt.transform.position.y) <= (stats.range * 1f))
                {
                    Debug.Log("Go");
                    gos[select].GetComponent<UnitStats>().health -= stats.attack;
                    if (gos[select].GetComponent<UnitStats>().health <= 0)
                    {
                        AudioHelper.PlayClip2D(_deathSound, 1f);
                        fesm.GetComponent<PlayerTurnState>()._units--;
                        gos[select].SetActive(false);
                    }
                    if (gos[select].GetComponent<UnitStats>().health > 0 && Mathf.Abs(gos[select].transform.position.x - gameObjectt.transform.position.x) <=
                    (gos[select].GetComponent<UnitStats>().range * 1f) && Mathf.Abs(gos[select].transform.position.y - gameObjectt.transform.position.y) <= (gos[select].GetComponent<UnitStats>().range * 1f))
                    {
                        stats.health -= gos[select].GetComponent<UnitStats>().attack;
                        if (stats.health <= 0)
                        {
                            AudioHelper.PlayClip2D(_deathSound, 1f);
                            fesm.GetComponent<EnemyTurnState>()._enemyUnits--;
                            fesm.GetComponent<EnemyTurnState>()._enemyUnitsLeft--;
                            gameObject.transform.parent.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
