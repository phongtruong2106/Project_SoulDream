using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float detectionRadius;
    [SerializeField] protected Transform handPosition;
    [SerializeField] protected bool isMove = true;
    [SerializeField] protected Animator animator;


    private void Update() {
        this.CheckPlayerInArea();
        this.CheckTouchPlayerMove();
    }

    protected virtual void MoveTowardsPlayer()
    {
        if(this.isMove)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            Vector3 targetPosition = player.position - directionToPlayer.normalized * detectionRadius;
            agent.SetDestination(targetPosition);
        }
    }
    
    protected virtual void CheckTouchPlayerMove()
    {
        if(enemyController._enemyCheckTouchPlayer._isTouch)
        {
            this.isMove = false;
        }
        if(!this.isMove)
        {
            animator.SetTrigger("isHandUp");
            player.position = handPosition.position;
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
