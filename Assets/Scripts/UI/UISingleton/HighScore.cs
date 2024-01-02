using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : Popup
{
    [SerializeField] private TextMeshProUGUI _textHighScore;
    [SerializeField] private Button _replay;
    private void Awake()
    {
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
