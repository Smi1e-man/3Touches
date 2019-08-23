using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //private visual values
    [SerializeField]
    StateActive _stateActive;
    [SerializeField]
    StateDisactive _stateDisactive;

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
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        _state.UpdateState();
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ChangeStateOnDisactive()
    {
        _state = _stateDisactive;
        //DELETE, when add holeEffectsActive
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void ChangeStateOnActive()
    {
        _state = _stateActive;
        //DELETE, when add holeEffectsActive
        GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        _state.BallEnter();
    }
}
