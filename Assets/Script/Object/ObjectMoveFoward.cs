using UnityEngine;

public class ObjectMoveFoward : ObjectMovement
{
    [SerializeField] protected CharacterController controller;

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
    }

    protected virtual void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);

        if(isGrounded)
        {
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
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity *  Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    protected virtual void Run()
    {
        moveSpeed = runSpeed;
    }

    protected virtual void Idle()
    {

    }

    protected virtual void Walk()
    {
        moveSpeed = walkSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}