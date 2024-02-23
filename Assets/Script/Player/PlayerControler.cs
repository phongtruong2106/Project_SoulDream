using UnityEngine;

public class PlayerControler : NewMonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] protected ObjectMovement objectMovement;
    public ObjectMovement _objectMovement => objectMovement;
    //[SerializeField] protected Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectMovement();
        //this.LoadAnimator();
    }

    protected virtual void LoadObjectMovement()
    {
        if(this.objectMovement != null) return;
        this.objectMovement = GetComponentInChildren<ObjectMovement>();
        Debug.Log(transform.name + ": LoadObjectMovement()", gameObject);
    }

    // protected virtual void LoadAnimator()
    // {
    //     if(this.animator != null) return;
    //     this.animator = GetComponentInChildren<Animator>();
    //     Debug.Log(transform.name + ": LoadAnimator()", gameObject);
    // }
}