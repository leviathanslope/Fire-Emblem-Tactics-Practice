using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject thisGameObject;
    public Slider healthSlider;

    private void Start()
    {
        healthSlider.maxValue = thisGameObject.GetComponent<EnemyStats>().health;
        healthSlider.value = thisGameObject.GetComponent<EnemyStats>().health;
    }

    private void Update()
    {
        healthSlider.value = thisGameObject.GetComponent<EnemyStats>().health;
    }
}
