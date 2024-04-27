using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickPlayer : NewMonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected GameObject objectHand;
    [SerializeField] protected GameObject playerObj;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    private void Update() {
        this.AttackPlayer();
        this.PickUpPlayer();
    }

    protected virtual void LoadEnemyController()
    {
        if(this.enemyController!= null) return;
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": LoadObjectCheckPlayer()", gameObject);
    }

    protected virtual void AttackPlayer()
    {
        if(enemyController._enemyCheckPlayer._isPlayer)
        {
            enemyController._animator.SetBool("isHandUp", true);
        }
        else
        {
            enemyController._animator.SetBool("isHandUp", false);
        }
    }

    protected virtual void PickUpPlayer()
    {
        if(enemyController._enemyCheckTouchPlayer._isTouch)
        {
           Vector3 handPosition = objectHand.transform.position;
            playerObj.transform.position = handPosition;
            Vector3 offset = playerObj.transform.position - handPosition;
            float yOffset = 1.0f;
            offset.y -= yOffset;
            playerObj.transform.position += offset;
        }
    }
}
