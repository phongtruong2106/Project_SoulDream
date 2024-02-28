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
    
    private void Update() {
        this.CheckRaycast();
    }
    protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // if (hit.collider.CompareTag("Box"))
        // {
        //     CheckInput();
        // }
        // if(isPushing)
        // {
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
        // }
        
    }

    protected virtual void CheckRaycast()
    {
        Debug.DrawRay(transform.position, Vector3.forward, Color.red,MAXDIS);
        if(Physics.Raycast(transform.position, Vector3.forward, MAXDIS, layerMask))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                turn = true;
                animator.SetBool("isPush", true);
                Debug.Log(turn);
            }
            this.CheckMove();
        }
    }

    protected virtual void CheckMove()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("isPush", false);
            turn = false;
        }
    }

}
