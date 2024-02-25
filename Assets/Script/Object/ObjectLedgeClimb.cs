using UnityEngine;

public class ObjectLedgeClimb : NewMonoBehaviour 
{
    
    [Header("ObjectLedgeClimb")]
    [SerializeField] protected Transform targetPointBegun;
    [SerializeField] protected Transform targetPointOver;
    [HideInInspector] public bool ledgeDetected;
    [SerializeField] protected Animator animator;
    private bool canClimbLedge = false;
    private bool canGrabLedge = true;
    private Vector3 TargetPoint1;
    private Vector3 TargetPoint2;

    private void Update() {
        CheckForLedge();
        AnimationController();
    }
    private void CheckForLedge()
    {
        if(ledgeDetected && canGrabLedge)
        {
            canGrabLedge = false;
            canClimbLedge = true;

            TargetPoint1 = new Vector3(targetPointBegun.position.x, targetPointBegun.position.y);
            TargetPoint2 = new Vector3(targetPointOver.position.x, targetPointOver.position.y);

            PlayerControler.instance._objectMovement.isMove = false;
        }
        
        if(canClimbLedge)
        {
            transform.parent.position = TargetPoint1;   
            PlayerControler.instance._objectMovement.isGrounded = true;
        }
    }

    public void LedgeClimbOver()
    {
        canClimbLedge = false;
        ledgeDetected = false;
        transform.parent.position = TargetPoint2;
        PlayerControler.instance._objectMovement.isMove = true;
        animator.SetBool("isClimbLedge", canClimbLedge);
        Invoke("AllowLedgeGrab", 0.1f);
      
    }
    protected virtual void AnimationController()
    {
        animator.SetBool("isClimbLedge", canClimbLedge);
    }
    private void AllowLedgeGrab() => canGrabLedge = true;
}