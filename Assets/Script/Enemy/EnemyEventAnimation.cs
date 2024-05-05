using UnityEngine;

public class EnemyEventAnimation : NewMonoBehaviour
{
    protected EnemyController enemyController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    protected virtual void LoadEnemyController()
    {
        
    }
}