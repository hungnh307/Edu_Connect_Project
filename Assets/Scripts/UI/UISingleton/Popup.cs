using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Color backgroundColor = new Color(10.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f, 0.6f);

    protected GameObject _background;
    private float _destroyTime = 0.5f;

    public void Open(Canvas canvas)
    {
        AddBackground(canvas);
    }
    public virtual void Close()
    {
        //RemoveBackground();
        var animator = GetComponent<Animator>();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            animator.Play("Close");
            Debug.Log("Play Close ");
        }
        StartCoroutine(RunPopupDestroy());
    }
    private IEnumerator RunPopupDestroy()
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(_background);
        Destroy(gameObject);
    }

    private void AddBackground(Canvas canvas)
    {
        var bgTex = new Texture2D(1, 1);
        bgTex.SetPixel(0, 0, backgroundColor);
        bgTex.Apply();

        _background = new GameObject("PopupBackground");
        var image = _background.AddComponent<Image>();
        var rect = new Rect(0, 0, bgTex.width, bgTex.height);
        var sprite = Sprite.Create(bgTex, rect, new Vector2(0.5f, 0.5f), 1);
        image.material.mainTexture = bgTex;
        image.sprite = sprite;
        var newColor = image.color;
        image.color = newColor;
        image.canvasRenderer.SetAlpha(0.0f);
        image.CrossFadeAlpha(1.0f, 0.4f, false);

        _background.transform.localScale = new Vector3(1, 1, 1);
        _background.GetComponent<RectTransform>().sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
        _background.transform.SetParent(canvas.transform, false);
        _background.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }
    private void RemoveBackground()
    {
        var image = _background.GetComponent<Image>();
        if (image != null)
            image.CrossFadeAlpha(0.0f, 0.2f, false);
    }
}
