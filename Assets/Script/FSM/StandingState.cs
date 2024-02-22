using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : State
{
    [SerializeField] protected float gravityValue;
    [SerializeField] protected bool jump;
    [SerializeField] protected bool climb;
    [SerializeField] protected Vector3 currentVelocity;
    [SerializeField] protected bool grounded;
    [SerializeField] protected bool sprint;
    [SerializeField] protected float player_Speed;
    [SerializeField] protected Vector3 cVelocity;
    public StandingState(PlayerControler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        playerControler = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        this.jump = false;
        this.climb = false;
        this.sprint = false;
        this.input = Vector2.zero;
        this.velocity = Vector3.zero;
        this.currentVelocity = Vector3.zero;
        this.gravityVelocity.y = 0;

        this.player_Speed = playerControler.Player_Speed;
        this.grounded = playerControler.CharacterController.isGrounded;
        this.gravityValue = playerControler.GravityValue;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if(jumpAction.triggered)
        {
            jump = true;
        }

        if(climbAction.triggered)
        {
            climb = true;
        }
        if(sprintAction.triggered)
        {
            sprint = true;
        }
        
        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * playerControler.CameraTransform.right.normalized  +  velocity.z * playerControler.CameraTransform.forward.normalized;
        velocity.y = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        playerControler.Animator.SetFloat("Speed", input.magnitude, playerControler.SpeedDampTime, Time.deltaTime);
        if(sprint)
        {
            stateMachine.ChangeState(playerControler.Sprinting);
        }
        if(jump)
        {
            stateMachine.ChangeState(playerControler.Jumping);
        }
        if(climb)
        {
            stateMachine.ChangeState(playerControler.ClimbWallState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = playerControler.CharacterController.isGrounded;
        
        if(grounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = 0f;
        }

        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, playerControler.VelocityDampTime);
    }

    public override void Exit()
    {
        base.Exit();

        gravityVelocity.y = 0f;
        playerControler.playerVelocity = new Vector3(input.x, 0, input.y);

        if(velocity.sqrMagnitude > 0)
        {
            playerControler.transform.rotation = Quaternion.LookRotation(velocity);
        }
    }
}
