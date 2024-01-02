using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupFinish : Popup
{
    [SerializeField] protected List<Image> _imgStars;

    private void OnEnable() 
    {
        _imgStars.ForEach(s => s.color = new Color(1f,1f,1f,0f));
    }
    public void SetAchievedStars(int starsObtained)
    {
         _imgStars.ForEach(s => s.color = new Color(1f,1f,1f,0f));
        for (int i = 0; i < starsObtained; i++)
        {
            _imgStars[i].color = new Color(1f,1f,1f,1f);
            _imgStars[i].rectTransform.sizeDelta = _imgStars[i].rectTransform.sizeDelta * 1.5f;
        }
    }
}
