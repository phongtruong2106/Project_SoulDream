using UnityEngine;

public class CheckEnemySitDown : NewMonoBehaviour
{
    protected EnemyController enemyController;
    protected bool isSitDown;
    protected void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {      
            this.isSitDown = true;
            Debug.Log("asd");
        }
    }
}