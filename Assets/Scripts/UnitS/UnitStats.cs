using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField] GameObject feStateController;
    [SerializeField] GameObject unitStateController;
    public int health = 25;
    public int attack = 5;
    public int range = 2;
    public bool selected = false;

    public void Update()
    {
        if (health <= 0)
        {
            GetComponent<PlayerTurnState>()._unitsLeft--;
            GetComponent<PlayerTurnState>()._units--;
            this.gameObject.SetActive(false);
        }
    }
}
