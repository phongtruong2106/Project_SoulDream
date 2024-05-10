using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckPlayer : Enemy
{
    public bool _isPlayer = false;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))       
        {
            _isPlayer = true;
            enemyController._CheckEnemySitDown.isSitDown = false;
        } 
    }
}
