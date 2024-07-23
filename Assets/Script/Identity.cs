using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Identity : MonoBehaviour
{
    [SerializeField]
    protected GameManager _gameManager;
    
    protected int _clicks, _credits;
    
    private float _timer;
    private bool _isPlaying;

    public Color identityColor = default;

    [SerializeField]
    private UnityEvent<string> _onCreditsChangedFeedbacks,_onTimerChangedFeedbacks;

    // Start is called before the first frame update

    public virtual int DefaultClickAmount => 3;

    private void Awake()
    {
        if( _gameManager == null )
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        ChangeCredits(5);
    }


    private void Update()
    {
        if(!_isPlaying)
        {
            return;
        }
        _timer += Time.deltaTime;
        var ts = TimeSpan.FromSeconds(_timer);
        _onTimerChangedFeedbacks.Invoke($"{ts.Minutes.ToString("00")}:{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}");
    }

    public void ChangeClicks(int clickAmount = 1)
    {
        _clicks += clickAmount;
        if (_clicks <=-1)
        {
            _gameManager.ChangeTurn(this);
            EndTurn();
            return;
        }
        
    }

    public void ChangeCredits(int creditsToAdd = 1)
    {
        _credits = Mathf.Clamp(_credits+creditsToAdd,0,999);
        _onCreditsChangedFeedbacks.Invoke(_credits.ToString());
    }

    public void StartTurn()
    { 
        _clicks = DefaultClickAmount;
        _isPlaying = true;
    }
    public void EndTurn()
    {
        _isPlaying =false;
    }

    public float GetTimer()
    {
        return _timer;
    }
    public int GetClicks()
    {
        return _clicks;
    }
}
