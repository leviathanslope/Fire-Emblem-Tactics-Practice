using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitSelect : UnitState
{
    [SerializeField] int _movementRef = 5;
    [SerializeField] int _movement;
    int _movementLast;
    public List<int> _inputList = new List<int>();
    [SerializeField] GameObject thisGameObject;
    Transform initialPos;
    Vector3 positions;
    public override void Enter()
    {
        Debug.Log(this.transform.parent.name + " selected");
        initialPos = thisGameObject.transform;
        positions = initialPos.position;
        if (_inputList.Count != 0)
        {
            _inputList.Clear();
        }
        if (_movementLast != 0)
        {
            _movement += _movementLast;
        }
        StateMachine.Cursor.SetActive(false);
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedCancel += OnPressedCancel;
        StateMachine.Input.PressedUp += OnPressedUp;
        StateMachine.Input.PressedDown += OnPressedDown;
        StateMachine.Input.PressedLeft += OnPressedLeft;
        StateMachine.Input.PressedRight += OnPressedRight;
    }

    
    public override void Exit()
    {
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedCancel -= OnPressedCancel;
        StateMachine.Input.PressedUp -= OnPressedUp;
        StateMachine.Input.PressedDown -= OnPressedDown;
        StateMachine.Input.PressedLeft -= OnPressedLeft;
        StateMachine.Input.PressedRight -= OnPressedRight;
        Debug.Log("We either attacking/waiting or back to finding something to select");
    }

    void OnPressedConfirm()
    {
        _movementLast = _movement;
        _movement = 0;
        StateMachine.ChangeState<UnitMenu>();
    }

    void OnPressedCancel()
    {
        _movement = _movementRef;
        StateMachine.Cursor.SetActive(true);
        thisGameObject.transform.position = positions;
        StateMachine.ChangeState<UnitSetUp>();
    }

    void OnPressedUp()
    {
        Transform pos = thisGameObject.transform;
        int last;
        if (_movement > 0)
        {
            pos.Translate(0, 0.99f, 0);
            if (_inputList.Count != 0)
            {
                last = _inputList.Last();
            }
            else
            {
                last = 5;
            }
            if (last == 1)
            {
                _movement++;
                _inputList.RemoveAt(_inputList.Count - 1);
            } 
            else
            {
                _movement--;
                _inputList.Add(0);
            }
        }
        else
        {
            if (_inputList.Count != 0)
            {
                last = _inputList.Last();
            }
            else
            {
                last = 5;
            }
            if (last == 1)
            {
                pos.Translate(0, 0.99f, 0);
                _movement++;
                _inputList.RemoveAt(_inputList.Count - 1);
            }
        }
    }

    void OnPressedDown()
    {
        Transform pos = thisGameObject.transform;
        int last;
        if (_movement > 0)
        {
            pos.Translate(0, -0.99f, 0);
            if (_inputList.Count != 0)
            {
                last = _inputList.Last();
            }
            else
            {
                last = 5;
            }
            if (last == 0)
            {
                _movement++;
                _inputList.RemoveAt(_inputList.Count - 1);
            } 
            else
            {
                _movement--;
                _inputList.Add(1);
            }
        } else
        {
            if (_inputList.Count != 0)
            {
                last = _inputList.Last();
            }
            else
            {
                last = 5;
            }
            if (last == 0)
            {
                pos.Translate(0, -0.99f, 0);
                _movement++;
                _inputList.RemoveAt(_inputList.Count - 1);
            }
        }
    }

    void OnPressedLeft()
    {
        Transform pos = thisGameObject.transform;
        int last;
        if (_movement > 0)
        {
            pos.Translate(-0.99f, 0, 0);
            if (_inputList.Count != 0)
            {
                last = _inputList.Last();
            }
            else
            {
                last = 5;
            }
            if (last == 3)
            {
                _movement++;
                _inputList.RemoveAt(_inputList.Count - 1);
            }
            else
            {
                _movement--;
                _inputList.Add(2);
            }
        }
        else
        {
            if (_inputList.Count != 0)
            {
                last = _inputList.Last();
            }
            else
            {
                last = 5;
            }
            if (last == 3)
            {
                pos.Translate(-0.99f, 0, 0);
                _movement++;
                _inputList.RemoveAt(_inputList.Count - 1);
            }
        }
    }

    void OnPressedRight()
    {
        Transform pos = thisGameObject.transform;
        int last;
        if (_movement > 0)
        {
            pos.Translate(0.99f, 0, 0);
            if (_inputList.Count != 0)
            {
                last = _inputList.Last();
            }
            else
            {
                last = 5;
            }
            if (last == 2)
            {
                _movement++;
                _inputList.RemoveAt(_inputList.Count - 1);
            }
            else
            {
                _movement--;
                _inputList.Add(3);
            }
        }
        else
        {
            if (_inputList.Count != 0)
            {
                last = _inputList.Last();
            }
            else
            {
                last = 5;
            }
            if (last == 2)
            {
                pos.Translate(0.99f, 0, 0);
                _movement++;
                _inputList.RemoveAt(_inputList.Count - 1);
            }
        }
    }
}
