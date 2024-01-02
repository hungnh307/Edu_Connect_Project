using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupChoseSubject : MonoBehaviour
{
    [SerializeField] private Button choseSubjectBtn;
    [SerializeField] private Button optionBtn;
    [SerializeField] private Button aboutUsBtn;

    private void Awake()
    {
        choseSubjectBtn.onClick.AddListener(OpenPopupChoseSubject);
        optionBtn.onClick.AddListener(OpenPopupChoseSubject);
        aboutUsBtn.onClick.AddListener(OpenPopupChoseSubject);
    }

    private void OpenPopupChoseSubject() { }

    private void OpenOption() { }

    private void OpenPopupAboutUs() { }
}
