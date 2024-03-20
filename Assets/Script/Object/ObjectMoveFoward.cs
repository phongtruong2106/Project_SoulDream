using UnityEngine;

public class ObjectMoveFoward : ObjectMovement
{
    [Header("ObjectMoveFoward")]
    [SerializeField] protected CharacterController controller;
    public CharacterController _characterController => controller;
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isJumping;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected float rotationSpeed = 10f;
    
    protected bool isFlipped = false;
    protected Vector3 previousMoveDirection;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterController();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.parent.GetComponent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerController()", gameObject);
    }
    protected virtual void LoadCharacterController()
    {
        if(this.controller != null) return;
        this.controller = transform.parent.GetComponent<CharacterController>();
        Debug.Log(transform.name + ": LoadCharacterController()", gameObject);
    }

    private void Update() {
        this.Move();
        this.Jump();
        this.IsMove();
        this.CheckCanDetected();
    }

    public virtual void IsMove()
    {
        if(moveX == 0 && moveZ == 0) 
        {
            isMovel = false;
        }
        else
        {
            isMovel = true;
        }
    }
    protected virtual void Move()
    {
        isGrounded = Physics.CheckSphere(transform.parent.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        moveX = Mathf.Abs(Input.GetAxis("Horizontal")) < 0.01f ? 0f : Input.GetAxis("Horizontal");
        moveZ = Mathf.Abs(Input.GetAxis("Vertical")) < 0.01f ? 0f : Input.GetAxis("Vertical");
        float zScale = Mathf.Abs(transform.localScale.z);
        float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude) / 2;
        moveDirection = new Vector3(moveX, 0, moveZ);
        
        if(isMove)
        {
            if(isGrounded)
            {
                animator.SetTrigger("Land");
                if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                {   
                    Walk();
                }
                else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                {
                    Run();
                    inputMagnitude *= 2;
                }
                else if(moveDirection == Vector3.zero)
                {
                    Idle();
                }
                moveDirection *= moveSpeed;  
                isGrounded = true;
                isJumping = false;
                animator.SetBool("isGround", true);
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);   
                animator.SetFloat("Speed", inputMagnitude, 0.05f, Time.deltaTime);
            }
            else 
            {
                isJumping = true;
                animator.SetBool("isJumping", true);
                animator.SetBool("isGround", false);
                isGrounded = false;
                if(isJumping && velocity.y > 0)
                {
                    animator.SetBool("isFalling", true);
                }
            }
            controller.Move(moveDirection * Time.deltaTime);
            velocity.y += gravity *  Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            this.HandleRotation();
        }
    }
    protected virtual void Run()
    {
        moveSpeed = runSpeed;     
    }
    protected virtual void Idle()
    {
        animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    protected virtual void Walk()
    {
        moveSpeed = walkSpeed;
    }
    protected virtual void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            isJumping = true;
            animator.SetBool("isJumping", true);
            animator.SetBool("isGround", false);
            animator.SetBool("isFalling", false);
        }
    }
    protected virtual void HandleRotation()
    {
        Vector3 positionToLookAT;
        positionToLookAT.x = moveDirection.x;
        positionToLookAT.y = 0.0f;
        positionToLookAT.z = moveDirection.z;
        Quaternion currentRotation = transform.parent.rotation;
        if(moveX != 0 || moveZ != 0)
        {
            animator.SetBool("isMoving", true);
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAT);
            transform.parent.rotation  =  Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    protected virtual void CheckCanDetected()
    {
        if(moveDirection.x != 0 || moveDirection.z != 0)
        {
            playerControler._objectLedgeDetection.canDetected = false;
        }
    }
}