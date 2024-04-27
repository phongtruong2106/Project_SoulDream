using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemy();
        this.LoadEnemyMovement();
        this.LoadEnemyCheckPlayer();
        this.LoadEnemyCheckTouchPlayer();
        this.LoadObjectPickPlayer();
        this.LoadAnimation();
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
}
