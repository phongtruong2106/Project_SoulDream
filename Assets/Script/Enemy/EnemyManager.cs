using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : NewMonoBehaviour
{
    [SerializeField] protected ObjectCheckPlayer objectCheckPlayer;
    public ObjectCheckPlayer _objectCheckPlayer => objectCheckPlayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectCheckPlayer();
    }

     protected virtual void LoadObjectCheckPlayer()
    {
        if(this.objectCheckPlayer != null) return;
        this.objectCheckPlayer = transform.GetComponentInChildren<ObjectCheckPlayer>();
        Debug.Log(transform.name + ": LoadObjectCheckPlayer()", gameObject);
    }
}
