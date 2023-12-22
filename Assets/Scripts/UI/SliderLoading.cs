using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderLoading : MonoBehaviour
{
    [SerializeField] private Slider LoadingSlider;
    [SerializeField] private Text   progress;

    private Tween tween;
    private float trueProgress;

    private void Awake()
    {
        this.LoadingSlider.value = 0f;
    }

    private void Start()
    {
        LoadNextScene();
    }

    public void UpdateProgress(float content)
    {
        progress.text = Mathf.Round(content * 100) + "%";
    }

    public void SetProgress(float progress)
    {
        if (!this.LoadingSlider) return;
        if (progress <= this.trueProgress) return;
        this.tween.Kill();
        this.tween = DOTween.To(
            getter: () => this.LoadingSlider.value,
            setter: value => this.LoadingSlider.value = value,
            endValue: this.trueProgress = progress,
            duration: 0.5f
        ).OnUpdate(() => { UpdateProgress(this.LoadingSlider.value); });
    }

    public UniTask CompleteLoading()
    {
        this.SetProgress(1f);

        return this.tween.AsyncWaitForCompletion().AsUniTask();
    }

    private async UniTask LoadNextScene()
    {
        await this.CompleteLoading();
        Resources.UnloadUnusedAssets().ToUniTask().Forget();
        SceneManager.LoadScene("2_MainScene");
    }
}