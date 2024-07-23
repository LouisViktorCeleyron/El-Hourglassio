using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Runner : Identity
{
    public override int DefaultClickAmount => 4;

    private int _tags, _coreDammages;

    [SerializeField]
    private UnityEvent<string> _onTagsChangeFeedback, _onCDChangeFeedback;

    public void ChangeTags(int amount = 1)
    {
        _tags = Mathf.Clamp(_tags + amount, 0, 999);
        _onTagsChangeFeedback.Invoke(_tags.ToString());
    }

    public void ChangeCoreDammage(int amount = 1)
    {
        _coreDammages = Mathf.Clamp(_coreDammages + amount, 0, 999);
        _onCDChangeFeedback.Invoke(_coreDammages.ToString());
    }
}
