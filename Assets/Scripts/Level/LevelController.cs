using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelModel       LevelModel;
    public List<GameObject> product;
    public List<GameObject> Molecules;

    private void Start()
    {
        product.ForEach(item => item.gameObject.SetActive(false));
    }

    public void OnChemicalReaction()
    {
        GameManager.Instance.screenAttack.UpdateText(this.LevelModel.levelInfo, this.LevelModel.leveDetail);
        this.Molecules.ForEach(Item => Item.gameObject.SetActive(false));
        product.ForEach(item =>
        {
            item.gameObject.transform.localScale = new Vector3(0, 0, 0);
            item.gameObject.SetActive(true);
            item.gameObject.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.InOutBack);
        });
    }
}

[Serializable]
public class LevelModel
{
    public string levelInfo;
    public string leveDetail;
}