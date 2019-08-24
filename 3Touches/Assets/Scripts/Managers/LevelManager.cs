using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    //private visual values
    [SerializeField] private List<Hole> _holes;
    [SerializeField] private List<GameObject> _LvlsObstacles;

    //private values
    private GameObject _activeObstacle;
    private int _currentLvl;
    private Vector3 _startPos;

    //public values
    public static LevelManager LvlM;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        if (LvlM == null)
            LvlM = this;
        _currentLvl = 0;
        _startPos = Vector3.zero;
        GenerateObstacle();
    }

    private void GenerateObstacle()
    {
        for (int i = 0; i < _LvlsObstacles.Count; i++)
        {
            _LvlsObstacles[i] = Instantiate(_LvlsObstacles[i]);
            _LvlsObstacles[i].transform.position = _startPos;
            _LvlsObstacles[i].SetActive(false);
        }
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ActivateRandomHole()
    {
        int rand = Random.Range(0, _holes.Count);
        for (int i = 0; i < _holes.Count; i++)
        {
            _holes[i].ChangeStateOnDisactive();
        }
        _holes[rand].ChangeStateOnActive();
    }
    
    public void LoadLevel(int lvl)
    {
        if (_activeObstacle != null)
            _activeObstacle.SetActive(false);
        _currentLvl = lvl;
        _activeObstacle = _LvlsObstacles[_currentLvl % _LvlsObstacles.Count];
        _activeObstacle.SetActive(true);
        ActivateRandomHole();
    }
}
