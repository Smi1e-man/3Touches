using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDisactive : MonoBehaviour, IStatesHole
{
    /// <summary>
    /// Public Methods.
    /// </summary>
    public void UpdateState()
    {
        ;
    }

    public void BallEnter()
    {
        GameManager.Gm.BallOnStart();
        GameManager.Gm.EndGame(false);
    }
}
