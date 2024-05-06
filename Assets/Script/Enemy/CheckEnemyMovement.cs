using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyMovement : NewMonoBehaviour
{
    [SerializeField]  protected EnemyController enemyController;
    [SerializeField] protected Transform objPosConfirm;
    public Transform ObjPosConfirm => objPosConfirm;
    public bool isCheck = false;
    public bool IsCheck => isCheck;
    public bool isEnemyStun = false;
    private Coroutine stunCoroutine;


    protected void Update()
    {
        this.CheckEnemy();
        this.ChangeStateMovent();
    }

    protected void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isCheck = true;
        }
    }
    protected void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isCheck = false;
        }
    }

    protected virtual void CheckEnemy()
    {
        if(isCheck)
        {
            enemyController.PianoController._notificationPiano.IsNotification = false;
            if (stunCoroutine == null)
            {
                stunCoroutine = StartCoroutine(StartStunTimer(0.5f));
            }
        }
    }

    protected virtual void ChangeStateMovent()
    {
        if(isEnemyStun)
        {
             enemyController._animator.SetBool("IsStun", false);
             enemyController._enemyMovement.objectPos = objPosConfirm;
             enemyController._enemyMovement.MoveTowardsPlayer();
        }
    }

    private IEnumerator StartStunTimer(float duration)
    {
        yield return new WaitForSeconds(duration);

        StunAnimation();
        isCheck = false;
        stunCoroutine = null;
    }

    protected virtual void StopStunAnimation()
    {
        enemyController._animator.SetBool("IsStun", false);
    }

    protected virtual void StunAnimation()
    {
        enemyController._animator.SetBool("IsStun", true);
    }

    public virtual void EventAnimation()
    {
        isCheck = false;
    }
}
