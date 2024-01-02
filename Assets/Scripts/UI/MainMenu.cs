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
    
    private readonly GameManager gameManager;

    // Constructor để inject GameManager
    public MainMenu(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    
    private void Start()
    {
        choseSubjectBtn.onClick.AddListener(OpenPopupChoseSubject);
        optionBtn.onClick.AddListener(OpenPopupChoseSubject);
        aboutUsBtn.onClick.AddListener(OpenPopupChoseSubject);
    }

    private void OpenPopupChoseSubject()
    {
        Debug.LogError(gameManager.Canvas.name);
        Popup prefab = Resources.Load<Popup>("UI/ChoseSubject");
        _popup = Instantiate(prefab, gameManager.Canvas.transform);
        _popup.Open(gameManager.Canvas);
    }

    private void OpenOption() { }

    private void OpenPopupAboutUs() { }
}
public class MainMenuFactory : PlaceholderFactory<MainMenu>
{
}