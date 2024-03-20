using UnityEngine;

public class ObjectBeingLifted : NewMonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
        this.LoadPlayerController();
    }

    private void Update() {
        this.CheckTouchPlayer();
    }

    protected virtual void LoadEnemyController()
    {
        if(this.enemyController != null) return;
        this.enemyController = FindAnyObjectByType<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyController()", gameObject);
    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerController()", gameObject);
    }

    protected void CheckTouchPlayer()
    {
        if(enemyController._enemyCheckTouchPlayer._isTouch)
        {
            animator.SetTrigger("isLiftUp");
            //playerControler._objectMoveFoward._characterController.enabled = false;
        }
    }
}