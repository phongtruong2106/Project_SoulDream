using UnityEngine;

public class EnemyCheckTouchPlayer : NewMonoBehaviour
{
    [SerializeField] protected bool isTouch = false;
    public bool _isTouch => isTouch;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) isTouch = true;
    }
}