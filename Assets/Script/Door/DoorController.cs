using UnityEngine;

public class DoorController : NewMonoBehaviour
{
    [SerializeField] protected Animator  animator;
    public Animator _animator => animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator()", gameObject);
    }
}