using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //private visual values
    [SerializeField] private StateActive _stateActive;
    [SerializeField] private StateDisactive _stateDisactive;

    //private values
    private IStatesHole _state;

    //public values
    public static Hole _hole;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        if (_hole == null)
            _hole = this;
        ChangeStateOnDisactive();
    }

    private void Update()
    {
        _state.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        _state.BallEnter();
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ChangeStateOnDisactive()
    {
        _state = _stateDisactive;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void ChangeStateOnActive()
    {
        _state = _stateActive;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
