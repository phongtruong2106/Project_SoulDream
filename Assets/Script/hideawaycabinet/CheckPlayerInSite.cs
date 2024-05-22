using UnityEngine;

public class CheckPlayerInSite : NewMonoBehaviour
{
    [SerializeField] protected bool isPlayerInSite;
    public bool IsPlayerInSite => isPlayerInSite;

    protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            
            this.isPlayerInSite = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
           this.isPlayerInSite = false;
        }
    }
}