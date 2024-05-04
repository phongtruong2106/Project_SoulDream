using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : Enemy
{
    public Transform objectPos;
    [SerializeField] protected float detectionRadius;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Vector3 movePositon;
    [SerializeField] protected Transform objectPosDefault;
    [SerializeField] protected Transform objectPosTrigger;
    protected bool isCheckTarget;
    public bool isMove = true;

    protected override void Start()
    {
        base.Start();
    }


    private void Update() {
        this.CheckPlayerInArea();
        this.EnemyFollowTarget();
        this.EnemyFinishMoventTarget();
    }
    protected virtual void CheckPlayerInArea()
    {
        if(enemyController._enemy._objectCheckPlayer._isPlayer)
        {
            this.MoveTowardsPlayer();
        }
    }
    public virtual void MoveTowardsPlayer()
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

    protected virtual void EnemyFollowTarget()
    {
        
        if(enemyController.PianoController._notificationPiano.IsNotification)
        {
            objectPos = objectPosTrigger;
            this.MoveTowardsPlayer();        
        }
    }
    
    protected virtual void EnemyFinishMoventTarget()
    {
        if(enemyController._checkEnemyMovement.IsCheck)
        {
            objectPos = enemyController._checkEnemyMovement.ObjPosConfirm;
            this.MoveTowardsPlayer();  
        }
    }
    
}
