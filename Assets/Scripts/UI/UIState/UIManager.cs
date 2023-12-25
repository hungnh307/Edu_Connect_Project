using UnityEngine;

public class UIManager : MonoBehaviour
{
    private IUIState currentState;
    
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("UIManager");
                    _instance = go.AddComponent<UIManager>();
                }
            }
            return _instance;
        }
    }

    public void ChangeState(IUIState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
    
    public void ShowLoadingPopup() { /* ... */ }
    public void HideLoadingPopup() { /* ... */ }

    public void ShowMainMenuPopup() { /* ... */ }
    public void HideMainMenuPopup() { /* ... */ }

    public void ShowChooseSubjectPopup() { /* ... */ }
    public void HideChooseSubjectPopup() { /* ... */ }
}
