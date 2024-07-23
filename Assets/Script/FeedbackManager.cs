using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _clicksText;
    [SerializeField]
    private RectTransform _clicksContainer;

    public void ManageCreditFeedbacks(Identity turnPlayer)
    {
        _clicksText.text = $"{turnPlayer.GetClicks()}/<color=#{ColorUtility.ToHtmlStringRGBA(turnPlayer.identityColor)}>{turnPlayer.DefaultClickAmount}</color>";
        _clicksContainer.eulerAngles = new Vector3(0, 0, turnPlayer.GetType() == typeof(Corp) ? 0 : 180);
    }
   
 
}
