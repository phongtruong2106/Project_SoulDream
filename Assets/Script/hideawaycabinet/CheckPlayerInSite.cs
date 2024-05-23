using UnityEngine;

public class CheckPlayerInSite : NewMonoBehaviour
{
    public bool isPlayerInSite;
    [SerializeField] protected PlayerControler playerControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            
            this.isPlayerInSite = true;
            playerControler._objectCrouch.isPlayerInSite = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
           this.isPlayerInSite = false;
           playerControler._objectCrouch.isPlayerInSite = false;
        }
    }
}