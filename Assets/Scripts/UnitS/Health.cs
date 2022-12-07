using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject thisGameObject;
    public Slider healthSlider;
    
    private void Start()
    {
        healthSlider.maxValue = thisGameObject.GetComponent<UnitStats>().health;
        healthSlider.value = thisGameObject.GetComponent<UnitStats>().health;
    }

    private void Update()
    {
        healthSlider.value = thisGameObject.GetComponent<UnitStats>().health;
    }
}
