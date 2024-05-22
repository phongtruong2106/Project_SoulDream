using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideawayCabinetController : NewMonoBehaviour
{
    [SerializeField] protected CheckPlayer checkPlayer;
    public CheckPlayer _checkPlayer => checkPlayer;
    [SerializeField] private Animator animator;
    public Animator _animator => animator;
    [SerializeField] protected CheckPlayerInSite checkPlayerInSite;
    public CheckPlayerInSite _checkPlayerInSite => checkPlayerInSite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCheckPlayer();
        this.LoadAnimator();
        this.LoadCheckPlayerInSite();
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

    protected virtual void LoadCheckPlayerInSite()
    {
        if(this.checkPlayerInSite != null) return;
        this.checkPlayerInSite = transform.GetComponentInChildren<CheckPlayerInSite>();
        Debug.Log(transform.name + ": LoadCheckPlayerInSite()", gameObject);
    }
}
