using Unity.VisualScripting;
using UnityEngine;

public class ObstaclePush : NewMonoBehaviour
{
    [SerializeField] protected float forceMagnitude;
    [SerializeField] protected bool isCanInput;
    [SerializeField] protected bool isPushing = false;
    [SerializeField] protected Animator animator;
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected float MAXDIS;
    [SerializeField] protected bool turn = false;
    [SerializeField] protected PlayerControler playerControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = GetComponent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerControler", gameObject);
    }

    private void Update() {
        this.CheckRaycast();
    }
    protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
    {
            Rigidbody rigidbody = hit.collider.attachedRigidbody;
            if(rigidbody != null)
            {
                if(turn == true)
                {
                    Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                    forceDirection.y = 0;
                    forceDirection.Normalize();
                    rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
                }
            }
        
    }

    protected virtual void CheckRaycast()
    {
        if(playerControler._objectPushDetected.pushDetected)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                turn = true;
                animator.SetBool("isPush", true);
            }
            else
            {
                turn = false;
            }
            this.CheckMove();
        }
    }

    protected virtual void CheckMove()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetBool("isPush", false);
            turn = false;
        }
    }
}
