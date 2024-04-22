using UnityEngine;

public class OpenBox : NewMonoBehaviour
{
    private Animator animator;
    private Piano piano;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPiano();
    }

    private void Update() {
        this.Open();
    }

    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator()", gameObject);
    }

    protected virtual void LoadPiano()
    {
        if(this.piano != null) return;
        this.piano = transform.parent.parent.GetComponent<Piano>();
        Debug.Log(transform.name + ": LoadPiano()", gameObject);
    }


    public virtual void Open()
    {
        if(this.piano.IsPressed)
        {
            animator.SetTrigger("BoxOpen");
        }
       
    }
}