using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : NewMonoBehaviour
{
    [SerializeField] protected  EnemyManager enemy;
    [SerializeField] protected EnemyCheckTouchPlayer enemyCheckTouchPlayer;
    public EnemyCheckTouchPlayer _enemyCheckTouchPlayer => enemyCheckTouchPlayer;
    public EnemyManager _enemy => enemy;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemy();
    }

    protected virtual void LoadEnemy()
    {
        if(this.enemy != null) return;
        this.enemy = FindAnyObjectByType<EnemyManager>();
        Debug.Log(transform.name + ": LoadEnemy()", gameObject);
    }
}
