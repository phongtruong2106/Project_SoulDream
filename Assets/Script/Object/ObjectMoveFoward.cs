using UnityEngine;

public class ObjectMoveFoward : ObjectMovement
{
    [Header("ObjectMoveFoward")]
    [SerializeField] protected CharacterController controller;
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isJumping;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected float rotationSpeed = 10f;

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
        Move();
        Jump();
    }

    protected virtual void Move()
    {
        isGrounded = Physics.CheckSphere(transform.parent.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        moveX = Mathf.Abs(Input.GetAxis("Horizontal")) < 0.01f ? 0f : Input.GetAxis("Horizontal");
        moveY = Mathf.Abs(Input.GetAxis("Vertical")) < 0.01f ? 0f : Input.GetAxis("Vertical");
        float zScale = Mathf.Abs(transform.localScale.z);
        float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude) / 2;
        moveDirection = new Vector3(moveX, 0, 0);
        
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

            if(moveX != 0 || moveY != 0)
            {
                animator.SetBool("isMoving", true);
                if (isMove && moveDirection != previousMoveDirection)
                {
                    if (moveDirection.x < 0)
                    {
                        Flip(-zScale);
                    }
                    else
                    {
                        Flip(zScale);
                    }
                }

                // Update previousMoveDirection
                previousMoveDirection = moveDirection;
            }   
            else
            {
                animator.SetBool("isMoving", false);
            }
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

    protected virtual void Flip(float scale)
    {
        Quaternion targetRotation = Quaternion.Euler(0, (scale < 0) ? -95 : 95, 0);
        transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //transform.parent.localScale = new Vector3(transform.parent.localScale.x, transform.parent.localScale.y, scale);
        playerControler._objectLedgeDetection.canDetected = false;
    }
}