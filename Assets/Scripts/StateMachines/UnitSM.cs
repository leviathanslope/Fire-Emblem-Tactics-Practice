using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSM : StateMachine
{
    [SerializeField] InputController _input;
    [SerializeField] UnitStats _stats;
    [SerializeField] GameObject cursor;
    
    public InputController Input => _input;
    public UnitStats Stats => _stats;
    public GameObject Cursor => cursor;

    void Start()
    {
        ChangeState<UnitSetUp>();
    }
}
