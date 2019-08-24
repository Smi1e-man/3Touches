using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //private visual values
    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _retry;
    [SerializeField] private GameObject _nextLvl;
    [SerializeField] private GameObject _grats;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _textBalls;
    [SerializeField] private TextMeshProUGUI _textTouch;

    //private values
    private int _touchMax;
    private int _ballMax;
    private int _touch;

    //public values
    public static UIManager UIM;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        if (UIM == null)
            UIM = this;
        _touchMax = Resources.Load<GameSetting>("Settings/GameSetting").TouchMax;
        _ballMax = Resources.Load<GameSetting>("Settings/GameSetting").BallMax;

    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void UpdateScreen()
    {
        _textBalls.text = "Balls = " + GameManager.Gm.GetBall() + "/" + _ballMax;
        _touch = GameManager.Gm.GetTouch();
        if (_touch == -1)
            _touch = 0;
        _textTouch.text = "Touch = " + _touch + "/" + _touchMax;
    }

    public void OffScreen()
    {
        _start.SetActive(false);
        _panel.SetActive(false);
        _nextLvl.SetActive(false);
        _grats.SetActive(false);
        _retry.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void StartScreen()
    {
        OffScreen();
        _start.SetActive(true);
        _panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextLvlScreen()
    {
        OffScreen();
        _panel.SetActive(true);
        _nextLvl.SetActive(true);
        _grats.SetActive(true);
        Time.timeScale = 0;
    }

    public void RetryScreen()
    {
        OffScreen();
        _panel.SetActive(true);
        _retry.SetActive(true);
        Time.timeScale = 0;
    }
}
