using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FESM))]
public class FEState : State
{
    protected FESM StateMachine { get; private set; }

    void Awake()
    {
        StateMachine = GetComponent<FESM>();
    }
}
