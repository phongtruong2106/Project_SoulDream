using UnityEngine;

public class NofiticationEnemy : NewMonoBehaviour
{
    public bool IsNotEnemy = false;
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected Transform ObjectConfirm;

    protected void Update() {
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    protected virtual void LoadEnemyController()
    {
        if(this.enemyController != null) return;
        this.enemyController = FindAnyObjectByType<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyController()", gameObject);
    }


}