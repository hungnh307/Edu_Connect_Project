using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimateUI : UIBehaviour, IPointerDownHandler
{
    public bool interactable = true;
    private Animator _animator;

    override protected void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left || !interactable)
            return;

        Press();
    }
    private void Press()
    {
        if (!IsActive())
            return;

        _animator.SetTrigger("Pressed");
        // Invoke("InvokeOnClickAction", 0.1f);
    }

}
