using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitSM))]
public class UnitState : State
{
    protected UnitSM StateMachine { get; private set; }

    void Awake()
    {
        StateMachine = GetComponent<UnitSM>();
    }
}
