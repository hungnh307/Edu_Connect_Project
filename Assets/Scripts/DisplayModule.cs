using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayModule : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text infoText;

    public void UpdateText(string nameText, string infoText)
    {
        this.nameText.text = nameText;
        this.infoText.text = infoText;
    }
}
