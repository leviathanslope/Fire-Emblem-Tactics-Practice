using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] GameObject feStateController;
    public int health = 25;
    public int attack = 5;
    public int range = 2;
    public int movement = 5;

    public void Update()
    {
        if (health <= 0)
        {
            GetComponent<EnemyTurnState>()._enemyUnitsLeft--;
            GetComponent<EnemyTurnState>()._enemyUnits--;
            this.gameObject.SetActive(false);
        }
    }
}
