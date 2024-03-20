using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : NewMonoBehaviour
{
    [SerializeField] protected  EnemyManager enemy;
    [SerializeField] protected EnemyCheckTouchPlayer enemyCheckTouchPlayer;
    public EnemyCheckTouchPlayer _enemyCheckTouchPlayer => enemyCheckTouchPlayer;
    public EnemyManager _enemy => enemy;
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement _enemyMovement => enemyMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemy();
        this.LoadEnemyMovement();
    }

    protected virtual void LoadEnemy()
    {
        if(this.enemy != null) return;
        this.enemy = FindAnyObjectByType<EnemyManager>();
        Debug.Log(transform.name + ": LoadEnemy()", gameObject);
    }

    protected virtual void LoadEnemyMovement()
    {
        if(this.enemyMovement != null) return;
        this.enemyMovement = transform.GetComponentInChildren<EnemyMovement>();
        Debug.Log(transform.name + ": LoadEnemyMovement()", gameObject);
    }
}
