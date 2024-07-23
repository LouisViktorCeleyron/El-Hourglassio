using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Corp : Identity
{ 
    public override int DefaultClickAmount => 3;

    private int _badPubs, _coreDammages;

    [SerializeField]
    private UnityEvent<string> _onBPChangeFeedback;

    public void ChangeBP(int amount = 1)
    {
        _badPubs = Mathf.Clamp(_badPubs + amount, 0, 999);
        _onBPChangeFeedback.Invoke(_badPubs.ToString());
    }
   
}

