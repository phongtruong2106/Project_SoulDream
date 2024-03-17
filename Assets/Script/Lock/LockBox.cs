using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBox : NewMonoBehaviour
{
    [SerializeField] protected Animator animator;
    private bool isOpenBox = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }
    private void Update() {
        this.CheckAfterLockOpe();
        this.OpenBox();
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadObjectPushDetected()", gameObject);
    }

    protected virtual void CheckAfterLockOpe()
    {
        if(LockManager.Instance.isAfterOpenLock)
        {
            this.isOpenBox = true;
        }
    }

    protected virtual void OpenBox()
    {
        if(this.isOpenBox)
        {
            animator.SetTrigger("IsBoxOpen");
        }
    }

}
