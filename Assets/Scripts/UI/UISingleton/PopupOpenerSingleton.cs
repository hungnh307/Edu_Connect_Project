using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupOpenerSingleton : MonoBehaviour
{
    public static PopupOpenerSingleton Instance;
    [SerializeField] private Canvas _canvas;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public virtual T OpenPopup<T>(string prefabPath) where T : Popup
    {
        Popup prefab = Resources.Load<Popup>(prefabPath);
        Popup popup = Instantiate(prefab, _canvas.transform);
        popup.Open(_canvas);
        return (T)popup;
    }
}
