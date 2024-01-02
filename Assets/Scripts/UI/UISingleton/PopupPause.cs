using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupPause : Popup
{
    [SerializeField] private Button _goHome;
    [SerializeField] private Button _continue;
    [SerializeField] private Button _replay;
    private void Awake()
    {
        _continue.onClick.AddListener(() => this.Close());
        _goHome.onClick.AddListener(Home);
        _replay.onClick.AddListener(Replay);
    }
    public override void Close()
    {
        base.Close();
    }
    public void Home()
    {
         StartCoroutine(LoadSceneString(0.5f,"Splash"));
    }
    public void Replay()
    {
        StartCoroutine(LoadSceneString(0.5f,"GamePlayBasic"));
    }
    IEnumerator LoadSceneString(float timeDelay, string nameScene)
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(nameScene);
    }
}
