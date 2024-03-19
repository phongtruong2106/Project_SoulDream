using System.Collections;
using UnityEngine;

public class ObjectLedgeClimb : NewMonoBehaviour 
{
    
    [Header("ObjectLedgeClimb")]
    [SerializeField] protected Transform targetPointBegun;
    [SerializeField] protected Transform targetPointOver;
    [SerializeField] protected Animator animator;
    [SerializeField] protected PlayerControler playerControler;
    private bool canClimbLedge = false;
    private bool canGrabLedge = true;
    private Vector3 TargetPoint1;
    private Vector3 TargetPoint2;
    [HideInInspector] public bool ledgeDetected;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.parent.GetComponent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerController()", gameObject);
    }
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
            //animator.applyRootMotion = true;
            TargetPoint1 = new Vector3(targetPointBegun.position.x, targetPointBegun.position.y);
            TargetPoint2 = new Vector3(targetPointOver.position.x, targetPointOver.position.y);
            playerControler._objectMoveFoward._characterController.enabled = false;
            PlayerControler.instance._objectMovement.isMove = false;
        }
        
        if(canClimbLedge)
        {
             if (!animator.IsInTransition(0))
            {
                animator.MatchTarget(TargetPoint1, Quaternion.identity, AvatarTarget.Root,
                                    new MatchTargetWeightMask(Vector3.one, 0), 0.1f, 0.5f);
            }
            PlayerControler.instance._objectMovement.isGrounded = true;
        }
    }

    public void LedgeClimbOver()
    {
        canClimbLedge = false;
        ledgeDetected = false;
        if (!animator.IsInTransition(0))
        {
            animator.MatchTarget(TargetPoint2, Quaternion.identity, AvatarTarget.Root,
                                new MatchTargetWeightMask(Vector3.one, 0), 0.1f, 0.5f);
        }
        playerControler._objectMoveFoward._characterController.enabled = true;
        animator.applyRootMotion = false;
        animator.SetBool("isClimbLedge", canClimbLedge);
        PlayerControler.instance._objectMovement.isMove = true;
        Invoke("AllowLedgeGrab", 0.1f);
    }
    protected virtual void AnimationController()
    {
        animator.SetBool("isClimbLedge", canClimbLedge);
    }
    private void AllowLedgeGrab() => canGrabLedge = true;

}