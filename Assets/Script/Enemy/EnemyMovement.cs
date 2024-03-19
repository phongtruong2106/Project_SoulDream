using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected float speed;


    private void Update() {
        this.CheckPlayerInArea();
    }

    protected virtual void MoveTowardsPlayer()
    {
        if(enemyController._enemyCheckTouchPlayer._isTouch)
        {
            agent.SetDestination(player.position);
        }
        
    }

    protected virtual void CheckPlayerInArea()
    {
        if(enemyController._enemy._objectCheckPlayer._isPlayer)
        {

            this.MoveTowardsPlayer();
        }
    }
}
