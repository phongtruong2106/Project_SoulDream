using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    protected bool grounded;
    protected float gravityValue;
    protected float jumpHeight;
    protected float playerSpeed;    

    protected Vector3 airVelocity;
    public JumpState(PlayerControler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        playerControler = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        this.grounded = false;
        this.gravityValue = playerControler.GravityValue;
        this.jumpHeight = playerControler.JumpHeight;
        this.playerSpeed = playerControler.Player_Speed;
        this.gravityVelocity.y = 0;

        playerControler.Animator.SetFloat("Speed", 0);
        playerControler.Animator.SetTrigger("Jump");
        this.Jump();
    }

    public override void HandleInput()
    {
        base.HandleInput();

        input = moveAction.ReadValue<Vector2>();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(grounded)
        {
            stateMachine.ChangeState(playerControler.Landing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(!grounded)
        {
            this.velocity = playerControler.playerVelocity;
            this.airVelocity = new Vector3(input.x, 0, input.y);

            this.velocity = velocity.x * playerControler.CameraTransform.right.normalized + velocity.z * playerControler.CameraTransform.forward.normalized;
            this.velocity.y = 0f;
            this.airVelocity = airVelocity.x * playerControler.CameraTransform.right.normalized + this.airVelocity.z * playerControler.CameraTransform.forward.normalized;
            this.airVelocity.y = 0f;
            playerControler.CharacterController.Move(gravityVelocity * Time.deltaTime + (this.airVelocity*playerControler.AirControl+velocity*(1- playerControler.AirControl)) * playerSpeed *Time.deltaTime);
        }

        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = playerControler.CharacterController.isGrounded;
    }

    public override void Exit()
    {
        base.Exit();
    }

    protected virtual void Jump()
    {
        gravityVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }
}
