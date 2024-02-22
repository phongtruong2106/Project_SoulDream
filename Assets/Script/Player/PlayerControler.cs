using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerControler : NewMonoBehaviour
{
    [Header("Controls")]
    [SerializeField] protected float player_Speed = 5.0f;
    public float Player_Speed => player_Speed;
    [SerializeField] protected float sprint_Speed = 7.0f;
    [SerializeField] protected float jump_Height = 0.8f;
    public float JumpHeight => jump_Height;
    [SerializeField] protected float gravity_Multiplier = 2.0f;
    [SerializeField] protected float rotationSpeed = 5.0f;

    [Header("Animation Smooting")]
    [Range(0, 1)]
    [SerializeField] protected float speedDampTime = 0.1f;
    public float SpeedDampTime => speedDampTime;
    [Range(0, 1)]
    [SerializeField] protected float velocityDampTime = 0.9f;
    public float VelocityDampTime => velocityDampTime;
    [Range(0, 1)]
    [SerializeField] protected float rotationDampTime = 0.2f;
    public float RotationDampTime => rotationDampTime;
    [Range(0, 1)]
    [SerializeField] protected float airControl = 0.5f;
    public float AirControl => airControl;

    [SerializeField] protected StateMachine movementSM;
    public StateMachine MovementSM => movementSM;
    [SerializeField] protected StandingState standing;
    public StandingState Standing => standing;
    [SerializeField] protected JumpState jumping;
    public JumpState Jumping => jumping;
    [SerializeField] protected LandingState landing;
    public LandingState Landing => landing;
    [SerializeField] protected SprintState sprinting;
    public SprintState Sprinting => sprinting;
    [SerializeField] protected ClimbWallState climbWallState;
    public ClimbWallState ClimbWallState => climbWallState;

    [HideInInspector] protected float gravityValue = -9.81f;
    public float GravityValue => gravityValue;
    [HideInInspector] protected float normalColliderHeight;
    [HideInInspector] protected CharacterController characterController;
    public CharacterController CharacterController => characterController;
    [HideInInspector] protected PlayerInput playerInput;
    public PlayerInput PlayerInput => playerInput;
    [HideInInspector] protected Transform cameraTransform;
    public Transform CameraTransform => cameraTransform;
    [HideInInspector] protected Animator animator;
    public Animator Animator => animator;
    [HideInInspector] public Vector3 playerVelocity;
    // public Vector3 PlayerVelocity => playerVelocity;


    protected override void Start()
    {
        base.Start();
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        movementSM.currentState.HandleInput();
        movementSM.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        movementSM.currentState.PhysicsUpdate();
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStateMachine();
        this.LoadSandingState();
        this.LoadJumpState();
        this.LoadLandingState();
        this.LoadSprintState();
        this.LoadCharacterControler();
        this.LoadAnimator();
        this.LoadPlayerInput();

        movementSM = new StateMachine();
        standing = new StandingState(this, movementSM);
        jumping = new JumpState(this, movementSM);
        landing= new LandingState(this, movementSM);
        sprinting = new SprintState(this, movementSM);

        movementSM.Initialize(standing);
        normalColliderHeight = characterController.height;
        gravityValue *= gravity_Multiplier;
    }

    
    protected virtual void LoadPlayerInput()
    {
        if(this.playerInput != null) return;
        this.playerInput = GetComponent<PlayerInput>();
        Debug.Log(transform.name + ": LoadPlayerInput()", gameObject);
    }


    protected virtual void LoadAnimator()
    {
        if(this.animator!= null) return;
        this.animator = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator()", gameObject);
    }


    protected virtual void LoadCharacterControler()
    {
        if(this.characterController!= null) return;
        this.characterController = GetComponent<CharacterController>();
        Debug.Log(transform.name + ": LoadCharacterControler()", gameObject);
    }

    protected virtual void LoadStateMachine()
    {
        if(this.movementSM != null) return;
        this.movementSM = GetComponentInChildren<StateMachine>();
        Debug.Log(transform.name + ": LoadStateMachine", gameObject);
    }

    protected virtual void LoadSandingState()
    {
        if(this.standing!= null) return;
        this.standing = GetComponentInChildren<StandingState>();
        Debug.Log(transform.name + ": LoadStandingState", gameObject);
    }

    protected virtual void LoadJumpState()
    {
        if(this.jumping != null) return;
        this.jumping = GetComponentInChildren<JumpState>();
        Debug.Log(transform.name + ": LoadJumpState", gameObject);
    }

    protected virtual void LoadLandingState()
    {   
        if(this.landing != null) return;
        this.landing = GetComponentInChildren<LandingState>();
        Debug.Log(transform.name + ": LoadLandingState", gameObject);
    }
    protected virtual void LoadSprintState()
    {   
        if(this.sprinting != null) return;
        this.sprinting = GetComponentInChildren<SprintState>();
        Debug.Log(transform.name + ": LoadSprintState", gameObject);
    }


}
