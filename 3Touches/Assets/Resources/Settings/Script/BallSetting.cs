using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallSetting", menuName = "BallSetting", order = 1)]
public class BallSetting : ScriptableObject
{
    [SerializeField, Range(0, 10)] private float   _BallImpulse;
    [SerializeField, Range(0, 1)] private float _Static_Friction;
    [SerializeField, Range(0, 1)] private float _Dynamic_Friction;
    [SerializeField, Range(0, 1)] private float _Bounciness;
    [SerializeField, Range(0, 10)] private float _Drag;
    [SerializeField, Range(1, 300)] private float _ScaleCoef;
    [SerializeField, Range(1, 3)] private float _ScaleMax;
    [SerializeField, Range(1, 3)] private float _ScaleMin;
    [SerializeField, Range(0, 1)] private float _SlowMotion;
    public float ScaleMax => _ScaleMax;
    public float ScaleMin => _ScaleMin;
    public float BallImpulse => _BallImpulse;
    public float Static_Friction => _Static_Friction;
    public float Dynamic_Friction => _Dynamic_Friction;
    public float Bounciness => _Bounciness;
    public float Drag => _Drag;
    public float Scale_Coef => _ScaleCoef;
    public float SlowMotion => _SlowMotion;
}
