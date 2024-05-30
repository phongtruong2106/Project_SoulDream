using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : NewMonoBehaviour
{
    [SerializeField] protected hideawayCabinetController hideawayCabinetController;
    [SerializeField] protected string textBox;
    [SerializeField] protected UIController uIController;
    protected bool isPlayer  = false;
    public bool IsPlayer => isPlayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
        this.LoadhideawayCabinetController();
    }

    protected virtual void LoadhideawayCabinetController()
    {
        if(this.hideawayCabinetController != null) return;
        this.hideawayCabinetController = transform.parent.GetComponent<hideawayCabinetController>();
        Debug.Log(transform.name + ": LoadhideawayCabinetController()", gameObject);
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }
     protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(true);
            uIController._uI_PressButton._text_ObjPress.text = textBox;
            this.isPlayer = true;
            
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
           uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(false);
           this.isPlayer = false;
        }
    }
    
}
