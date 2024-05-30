using UnityEngine;

public class ItemCheck : NewMonoBehaviour
{
    public bool isPlayer = false;

    protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            isPlayer = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
           isPlayer = false;
        }
    }
     
}