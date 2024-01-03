using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupChoseSubject : Popup
{
    [SerializeField] private Button choseSubjectBtn;
    [SerializeField] private Button backBtn;

    public void InitButton()
    {
        SetOnclick();
    }

    private void SetOnclick()
    {
        this.backBtn.onClick.AddListener(this.BackBtn);
    }
    private void OpenPopupChoseSubject() { }

    private void BackBtn()
    {
        GameManager.Instance.mainMenuPopup.ShowPopup();
        
    }

    private void OpenPopupAboutUs() { }
}
