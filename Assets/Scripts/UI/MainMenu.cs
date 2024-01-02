using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenu : Popup
{
    [SerializeField] private Button choseSubjectBtn;
    [SerializeField] private Button optionBtn;
    [SerializeField] private Button aboutUsBtn;
    private                  Popup  _popup;
    
    private void Start()
    {
        choseSubjectBtn.onClick.AddListener(OpenPopupChoseSubject);
        optionBtn.onClick.AddListener(OpenPopupChoseSubject);
        aboutUsBtn.onClick.AddListener(OpenPopupChoseSubject);
    }

    private void OpenPopupChoseSubject()
    {
        Popup prefab = Resources.Load<Popup>("UI/ChoseSubject");
        Debug.LogError(prefab.name);
        _popup = Instantiate(prefab, GameManager.Instance.Canvas.transform);
        _popup.Open(GameManager.Instance.Canvas);
    }

    private void OpenOption() { }

    private void OpenPopupAboutUs() { }
}
public class MainMenuFactory : PlaceholderFactory<MainMenu>
{
}