using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSetting", menuName = "GameSetting", order = 2)]
public class GameSetting : ScriptableObject
{
    [SerializeField, Range(1, 10)] private int _TouchMax;
    [SerializeField, Range(1, 10)] private int _BallMax;
    public int TouchMax => _TouchMax;
    public int BallMax => _BallMax;
}
