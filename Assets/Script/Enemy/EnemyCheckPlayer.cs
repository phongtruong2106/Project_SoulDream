using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckPlayer : MonoBehaviour
{
    [SerializeField] protected bool isPlayer = false;
    public bool _isPlayer => isPlayer;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) isPlayer = true;
    }
}
