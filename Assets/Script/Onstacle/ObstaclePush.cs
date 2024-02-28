using UnityEngine;

public class ObstaclePush : NewMonoBehaviour
{
    [SerializeField] protected float forceMagnitude;
    [SerializeField] protected bool isCanInput;
    [SerializeField] protected bool isPushing = false;
    [SerializeField] protected Animator animator;
    
    private void Update() {
        this.CheckMove();
    }
    protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Box"))
        {
            CheckInput();
        }
        if(isPushing)
        {
            Rigidbody rigidbody = hit.collider.attachedRigidbody;
            if(rigidbody != null)
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
        }
        
    }

    protected virtual void CheckMove()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (isPushing)
            {
                StopPushing();
            }
        }
    }
    protected virtual void StartPushing()
    {
        isPushing = true;
        animator.SetBool("isPush", true);
    }
    protected virtual void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (isPushing)
            {
                StopPushing();
            }
            else
            {
                StartPushing();
            }
        
        }
    }

    protected virtual void StopPushing()
    {

        isPushing = false;
    }

}
