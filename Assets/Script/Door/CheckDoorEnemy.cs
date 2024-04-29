using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoorEnemy : NewMonoBehaviour
{
    protected DoorController doorController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDoorController();
    }

    protected virtual void LoadDoorController()
    {

        if(this.doorController != null) return;
        this.doorController = transform.parent.GetComponent<DoorController>();
        Debug.Log(transform.name + ": LoadDoorController()", gameObject);
    }


    protected void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            doorController._animator.SetBool("isOpen", true);
        }   

    }

    protected void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            doorController._animator.SetBool("isOpen", false);
        }   
    }
}
