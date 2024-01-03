using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameManager : ThePattern.Unity.Singleton<GameManager>
{
    [SerializeField] public Canvas Canvas;
    public                  Popup  mainMenuPopup;
    public                  Camera  Camera;

    public DisplayModule screenInfo;
    public DisplayModule screenAttack;
    
    
    private void Start()
    {
        OpenMainMenu();
    }

    private void OpenMainMenu()
    {
        if (mainMenuPopup == null)
        {
            Popup prefab = Resources.Load<Popup>("UI/MainMenu");
            mainMenuPopup = Instantiate(prefab, GameManager.Instance.Canvas.transform);
            mainMenuPopup.Open(GameManager.Instance.Canvas);
        }
        else
        {
            mainMenuPopup.gameObject.SetActive(true);
        }
    }
}
