using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    //private visual values
    [SerializeField] private GameObject _Ball;

    //private values
    private Vector3 _BallPos;
    private Rigidbody _BallRb;
	private bool _game;
	private bool _win;
	private bool _BallStay;
	private int _currentLvl;
	private int _touchMax;
    private int _touch;
    private int _ball;
    private int _ballMax;

    //public values
    public static GameManager Gm;
	
    /// <summary>
    /// Private Methods.
    /// </summary>
	private void Awake()
	{
		if (Gm == null)
			Gm = this;
		_currentLvl = 0;
		_ballMax = Resources.Load<GameSetting>("Settings/GameSetting").BallMax;
		_touchMax = Resources.Load<GameSetting>("Settings/GameSetting").TouchMax;
		_game = false;
		_win = false;
	}

    private void Start()
    {
	    _BallRb = _Ball.GetComponent<Rigidbody>();
        ChangeLvlScreen(0);
	    _BallPos = _Ball.transform.position;
    }

    private void Update()
	{
		UIManager.UIM.UpdateScreen();
		Check();
	}

	private void ChangeLvlScreen(int n)
	{
		if (n == 0)
		{
			UIManager.UIM.StartScreen();
			LevelManager.LvlM.LoadLevel(_currentLvl);
		}
		else if (_win)
		{
			UIManager.UIM.NextLvlScreen();
			LevelManager.LvlM.LoadLevel(++_currentLvl);
		}
		else
		{
			UIManager.UIM.RetryScreen();
			LevelManager.LvlM.LoadLevel(_currentLvl);
			BallOnStart();
		}
		RefreshBall();
		RefreshTouch();
		_game = true;
		_win = false;
	}

	private void Check()
	{
		if (_ball == _ballMax)
			EndGame(true);
		if ((_touch == _touchMax && _BallStay) || (_touch > _touchMax))
			EndGame(false);
	}

	private void RefreshBall()
    {
	    _ball = 0;
    }
	
	private void RefreshTouch()
	{
		_touch = -1;
	}

    private IEnumerator Stay()
    {
        yield return new WaitForSeconds(10);
        _BallStay = true;
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void EndGame(bool win)
    {
        _game = false;
        _win = win;
        ChangeLvlScreen(1);
    }

    public void BallMove()
    {
        StopCoroutine(Stay());
        _BallStay = false;
        StartCoroutine(Stay());

    }
    public void Goal()
    {
        _ball += 1;
        LevelManager.LvlM.ActivateRandomHole();
        RefreshTouch();
        Touch();
    }

    public void BallOnStart()
    {
        _BallRb.velocity = Vector3.zero;
        _Ball.transform.position = _BallPos;
    }

    public void Touch()
    {
        _touch++;
    }

    public int GetTouch()
    {
        return _touch;
    }

    public int GetBall()
    {
        return _ball;
    }

}
