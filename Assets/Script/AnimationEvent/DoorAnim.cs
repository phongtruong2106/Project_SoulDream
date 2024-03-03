using UnityEngine;

public class DoorAnim : NewMonoBehaviour
{
    [Header("Player Controller")]
    public static DoorAnim instance;
    [SerializeField] protected Animator animator;

    protected override void Awake()
    {
        base.Awake();
        if(DoorAnim.instance != null) Debug.LogError("Only 1 DoorAnim allow to ");
        DoorAnim.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator()", gameObject);
    }

    public void OpenDoor()
    {
        animator.SetTrigger("isOpen");
    }
}