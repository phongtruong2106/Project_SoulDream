using UnityEngine;

public class ObjectMoveFoward : ObjectMovement
{
    [SerializeField] protected CharacterController controller;
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isJumping;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterController();
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
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        float xScale =Mathf.Abs(transform.localScale.x);
        float ySpeed = velocity.y;
        moveDirection = new Vector3(moveX, 0, moveZ);
        //moveDirection = transform.TransformDirection(moveDirection);
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
            }
            else if(moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= walkSpeed;  
            animator.SetBool("isGround", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);   
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

        if(moveX < 0)
        {
            transform.parent.localScale = new Vector3(-xScale, transform.parent.localScale.y, transform.parent.localScale.z);
        }
        else
        {
            transform.parent.localScale = new Vector3(xScale, transform.parent.localScale.y, transform.parent.localScale.z);
        }
        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity *  Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    protected virtual void Run()
    {
        moveSpeed = runSpeed;
        animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        
    }
    protected virtual void Idle()
    {
        animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    protected virtual void Walk()
    {
        moveSpeed = walkSpeed;
        animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    protected virtual void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        } 
    }
}