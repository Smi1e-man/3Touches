using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateActive : MonoBehaviour, IStatesHole
{
    /// <summary>
    /// Private Methods.
    /// </summary>

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void UpdateState()
    {
        ;
    }

    public void BallEnter()
    {
        GameManager.Gm.Goal();
        GameManager.Gm.BallOnStart();
    }
}
