using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Canvas Canvas;
    private                  Popup  _popup;
    
    private MainMenuFactory mainMenuFactory;

    [Inject]
    public void Contruct(MainMenuFactory mainMenuFactory)
    {
        this.mainMenuFactory = mainMenuFactory;
    }
    
    private void Start()
    {
        
        MainMenu main = mainMenuFactory.Create();
        
        // Popup prefab = Resources.Load<Popup>("UI/MainMenu");
        // _popup = Instantiate(prefab, Canvas.transform);
        //  _popup.Open(Canvas);
    }
}
