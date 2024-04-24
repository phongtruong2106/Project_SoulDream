using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUIPressKey : NewMonoBehaviour
{
    protected UI_PressButton uI_PressButton;
    [SerializeField] protected string textBox;
    [SerializeField] protected ZoomPuzzel zoomPuzzel;
    protected UIController uIController;
    protected bool isZoom;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIPressButton();
        this.LoadUIController();
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
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
            uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(true);
            uI_PressButton._text_ObjPress.text = textBox;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
           uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(false);
        }
    }
}
