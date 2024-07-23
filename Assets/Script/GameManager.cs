using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [HideInInspector]
    public Identity turnPlayer;
    [SerializeField]
    private Corp _corp;
    [SerializeField]
    private Runner _runner;
    private TimeSpan _generalTimer => TimeSpan.FromSeconds(_corp.GetTimer()+_runner.GetTimer());
    // Start is called before the first frame update

    [SerializeField]
    private UnityEvent<string> _onTimerChanged;
    [SerializeField]
    private UnityEvent<Identity> _onClicksChangedFeedback;


    private void Awake()
    {
        _corp = FindObjectOfType<Corp>();   
        _runner = FindObjectOfType<Runner>();
    }
    void Start()
    {
        _corp.StartTurn();
        turnPlayer = _corp;
        _onClicksChangedFeedback.Invoke(turnPlayer);
    }
    private void Update()
    {
     _onTimerChanged.Invoke($"{_generalTimer.Hours.ToString("00")}:{_generalTimer.Minutes.ToString("00")}:{_generalTimer.Seconds.ToString("00")}");   
    }

    public void ChangeClicks(int i)
    {
        turnPlayer.ChangeClicks(i);
        _onClicksChangedFeedback.Invoke(turnPlayer);
    }
    public void ChangeTurn(Identity exPlayer)
    {
        turnPlayer = (exPlayer == _corp?_runner:_corp);
        turnPlayer.StartTurn();
    }
}
