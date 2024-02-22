using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class State
{
    [SerializeField] protected  PlayerControler playerControler;
    [SerializeField] protected StateMachine stateMachine;

    protected Vector3 gravityVelocity;
    protected Vector3 velocity;
    protected Vector2 input;

    public InputAction moveAction;
    public InputAction lookAction;
    public InputAction jumpAction;
    public InputAction sprintAction;
    public InputAction climbAction;

    public State(PlayerControler _character, StateMachine _stateMachine)
    {
        playerControler = _character;
        stateMachine = _stateMachine;

        moveAction = playerControler.PlayerInput.actions["Move"];
        lookAction = playerControler.PlayerInput.actions["Look"];
        jumpAction = playerControler.PlayerInput.actions["Jump"];
        sprintAction = playerControler.PlayerInput.actions["Sprint"];
        climbAction = playerControler.PlayerInput.actions["ClimdWall"];

    }
    
    public virtual void Enter()
    {
        Debug.Log("enter state:" + this.ToString());
    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
