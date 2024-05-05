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
    private Coroutine stunCoroutine;

    protected void Update()
    {
        this.CheckEnemy();
    }

    protected void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isCheck = true;
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
        else if(!isCheck)
        {
           enemyController._enemyMovement.objectPos = objPosConfirm;
           enemyController._animator.SetBool("IsStun", false);
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

    protected virtual void StunAnimation()
    {
        enemyController._animator.SetBool("IsStun", true);
    }

    public virtual void EventAnimation()
    {
        isCheck = false;
    }
}
