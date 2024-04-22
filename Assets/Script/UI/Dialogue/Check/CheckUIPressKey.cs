using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUIPressKey : NewMonoBehaviour
{
    protected bool isPlayer;
    [SerializeField] protected UI_PressButton uI_PressButton;
    [SerializeField] protected GameObject uI_PressButtonObj;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIPressButton();
    }
    private void Update() {
        this.OpenUIPress();
    }

    protected virtual void LoadUIPressButton()
    {
         if(this.uI_PressButton != null) return;
        this.uI_PressButton = FindAnyObjectByType<UI_PressButton>();
        Debug.Log(transform.name + ": LoadUIPressButton()", gameObject);
    }

    protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            this.isPlayer = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            this.isPlayer = false;
        }
    }

    protected virtual void OpenUIPress()
    {
        if(this.isPlayer)
        {
            uI_PressButtonObj.gameObject.SetActive(true);
        }
    }
}
