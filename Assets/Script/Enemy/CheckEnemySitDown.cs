using UnityEngine;

public class CheckEnemySitDown : NewMonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected GameObject objEnemy;
    public bool isSitDown;

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
            enemyController._checkEnemyMovement.isEnemyStun = false;
            objEnemy.transform.rotation = Quaternion.Euler(0, 172.443f, 0);
            Vector3 newPos = objEnemy.transform.position;
            newPos.z = -4.43f;
            objEnemy.transform.position = newPos;
            
        }
    }
}