using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : NewMonoBehaviour
{
    [SerializeField] protected  EnemyManager enemy;
    [SerializeField] protected EnemyCheckTouchPlayer enemyCheckTouchPlayer;
    public EnemyCheckTouchPlayer _enemyCheckTouchPlayer => enemyCheckTouchPlayer;
    [SerializeField] protected EnemyCheckPlayer enemyCheckPlayer;
    public EnemyCheckPlayer _enemyCheckPlayer => enemyCheckPlayer;
    public EnemyManager _enemy => enemy;
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement _enemyMovement => enemyMovement;
    [SerializeField] protected ObjectPickPlayer objectPickPlayer;
    public ObjectPickPlayer _objectPickPlayer => objectPickPlayer;
    [SerializeField] protected Animator animator;
    public Animator _animator => animator;   
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected PianoController pianoController;
    public PianoController PianoController => pianoController;
    protected CheckEnemyMovement checkEnemyMovement;
    public CheckEnemyMovement _checkEnemyMovement => checkEnemyMovement;
    protected CheckEnemySitDown checkEnemySitDown;
    public CheckEnemySitDown _CheckEnemySitDown => checkEnemySitDown;
    [SerializeField] protected EnemyLookedPlayer enemyLookedPlayer;
    public EnemyLookedPlayer _enemyLookedPlayer => enemyLookedPlayer;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemy();
        this.LoadEnemyMovement();
        this.LoadEnemyCheckPlayer();
        this.LoadEnemyCheckTouchPlayer();
        this.LoadObjectPickPlayer();
        this.LoadAnimation();
        this.LoadNavMeshAgent();
        this.LoadPianoController();
        this.LoadCheckEnemyMovement();
        this.LoadCheckEnemySitDown();
        this.LoadEnemyLookedPlayer();
    }

    protected virtual void LoadCheckEnemyMovement()
    {
        if(this.checkEnemyMovement != null) return;
        this.checkEnemyMovement = FindAnyObjectByType<CheckEnemyMovement>();
        Debug.Log(transform.name + ": LoadCheckEnemyMovement()", gameObject);
    }

    protected virtual void LoadPianoController()
    {
        if(this.pianoController != null) return;
        this.pianoController = FindAnyObjectByType<PianoController>();
        Debug.Log(transform.name + ": LoadPianoController()", gameObject);
    }
    protected virtual void LoadNavMeshAgent()
    {
        if(this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadNavMeshAgent()", gameObject);
    }

    protected virtual void LoadAnimation()
    {
        if(this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LLoadAnimation()", gameObject);
    }

    protected virtual void LoadObjectPickPlayer()
    {
        if(this.objectPickPlayer != null) return;
        this.objectPickPlayer = transform.GetComponentInChildren<ObjectPickPlayer>();
        Debug.Log(transform.name + ": LoadObjectPickPlayer()", gameObject);
    }

    protected virtual void LoadEnemy()
    {
        if(this.enemy != null) return;
        this.enemy = FindAnyObjectByType<EnemyManager>();
        Debug.Log(transform.name + ": LoadEnemy()", gameObject);
    }
    protected virtual void LoadEnemyCheckPlayer()
    {
        if(this.enemyCheckPlayer != null) return;
        this.enemyCheckPlayer = FindAnyObjectByType<EnemyCheckPlayer>();
        Debug.Log(transform.name + ": LoadEnemyCheckPlayer()", gameObject);
    }

    protected virtual void LoadEnemyMovement()
    {
        if(this.enemyMovement != null) return;
        this.enemyMovement = transform.GetComponentInChildren<EnemyMovement>();
        Debug.Log(transform.name + ": LoadEnemyMovement()", gameObject);
    }
    protected virtual void LoadEnemyCheckTouchPlayer()
    {
        if(this.enemyCheckTouchPlayer != null) return;
        this.enemyCheckTouchPlayer = FindAnyObjectByType<EnemyCheckTouchPlayer>();
        Debug.Log(transform.name + ": LoadEnemyCheckTouchPlayer()", gameObject);
    }

    protected virtual void LoadCheckEnemySitDown()
    {
        if(this.checkEnemySitDown != null) return;
        this.checkEnemySitDown = FindAnyObjectByType<CheckEnemySitDown>();
        Debug.Log(transform.name + ": LoadCheckEnemySitDown()", gameObject);
    }

    protected virtual void LoadEnemyLookedPlayer()
    {
        if(this.enemyLookedPlayer != null) return;
        this.enemyLookedPlayer = transform.GetComponentInChildren<EnemyLookedPlayer>();
        Debug.Log(transform.name + ": LoadEnemyLookedPlayer()", gameObject);
    }
}
