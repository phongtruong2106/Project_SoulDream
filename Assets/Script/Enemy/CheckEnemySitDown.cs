using UnityEngine;

public class CheckEnemySitDown : NewMonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    protected bool isSitDown;

    protected virtual void Update()
    {
        this.isSitDownEnemy();
    }
    protected void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isSitDown = true;
        }
    }
    protected void OnTriggerExit(Collider collider)
    {
       if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isSitDown = false;
        } 
    }

    protected virtual void isSitDownEnemy()
    {
        if(isSitDown)
        {
            enemyController._animator.SetFloat("IsMove", 0);
        }
    }
}