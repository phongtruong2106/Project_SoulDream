using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideawayCabinetController : NewMonoBehaviour
{

    [SerializeField] protected CheckPlayer checkPlayer;
    public CheckPlayer _checkPlayer => checkPlayer;
    [SerializeField] private Animator animator;
    public Animator _animator => animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCheckPlayer();
        this.LoadAnimator();
    }
    protected virtual void LoadCheckPlayer()
    {
        if(this.checkPlayer != null) return;
        this.checkPlayer = transform.GetComponentInChildren<CheckPlayer>();
        Debug.Log(transform.name + ": LoadCheckPlayer())", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator()", gameObject);
    }
}
