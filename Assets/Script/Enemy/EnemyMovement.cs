using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : Enemy
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float detectionRadius;
    [SerializeField] protected Transform handPosition;
    [SerializeField] protected bool isMove = true;
    public bool _isMove => isMove;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Vector3 position;
    [SerializeField] protected Vector3 movePositon;
     
    private void Update() {
        this.CheckPlayerInArea();
    }
    protected virtual void CheckPlayerInArea()
    {
        if(enemyController._enemy._objectCheckPlayer._isPlayer)
        {
            this.MoveTowardsPlayer();
        }
    }

    protected virtual void MoveTowardsPlayer()
    {
        if(this.isMove)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            Vector3 targetPosition = player.position - directionToPlayer.normalized * detectionRadius;
            agent.SetDestination(targetPosition);
            movePositon = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.position.z);
            float inputMagnitude = Mathf.Clamp01(movePositon.magnitude);
            animator.SetFloat("IsMove", inputMagnitude);
        }
    }
    


}
