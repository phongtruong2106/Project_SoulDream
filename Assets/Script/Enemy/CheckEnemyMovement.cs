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

    protected void Update()
    {
        this.CheckEnemy();
    }

    protected void OnTriggerEnter(Collider collider)
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
        }
    }
}
