using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : MonoBehaviour
{
   
   protected virtual void OnTriggerEnter(Collider collision)
   {
        if (collision.gameObject.layer == LayerMask.NameToLayer("UI")) {
            UIController.instance.OpenObjPress();
        }
   }
    
   protected virtual void OnTriggerExit(Collider collision)
   {
        if (collision.gameObject.layer == LayerMask.NameToLayer("UI")) {
            UIController.instance.CloseObjPress();
        }
   }
}
