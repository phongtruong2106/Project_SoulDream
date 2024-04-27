using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : Enemy
{
    [SerializeField] protected Transform objectPos;
    [SerializeField] protected float detectionRadius;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Vector3 movePositon;
    public bool isMove = true;

     
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
            Vector3 directionToPlayer = objectPos.position - transform.position;
            Vector3 targetPosition = objectPos.position - directionToPlayer.normalized * detectionRadius;
            enemyController.Agent.SetDestination(targetPosition);
            movePositon = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.position.z);
            float inputMagnitude = Mathf.Clamp01(movePositon.magnitude);
            animator.SetFloat("IsMove", inputMagnitude);
        }
    }
    


}
