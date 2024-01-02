using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameManager : ThePattern.Unity.Singleton<GameManager>
{
    [SerializeField] public Canvas Canvas;
    private                  Popup  _popup;
    
    private void Start()
    {
        
        Popup prefab = Resources.Load<Popup>("UI/MainMenu");
        _popup = Instantiate(prefab,GameManager.Instance.Canvas.transform);
         _popup.Open(GameManager.Instance.Canvas);
    }
}
