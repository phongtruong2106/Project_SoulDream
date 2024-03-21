using UnityEngine;

public class ObjectCheckLiftPlayer : NewMonoBehaviour
{
    [SerializeField] protected bool isPlayer = false;
    public bool _isPlayer => isPlayer;
    [SerializeField] protected LayerMask layerMask;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) isPlayer = true;
    }


}