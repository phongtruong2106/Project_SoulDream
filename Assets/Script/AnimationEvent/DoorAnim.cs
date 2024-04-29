using UnityEngine;

public class DoorAnim : NewMonoBehaviour
{
    [Header("Player Controller")]
    public static DoorAnim instance;

    [SerializeField] protected DoorController doorController;
 
    protected override void Awake()
    {
        base.Awake();
        if(DoorAnim.instance != null) Debug.LogError("Only 1 DoorAnim allow to ");
        DoorAnim.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDoorController();
    }
    protected virtual void LoadDoorController()
    {
        if(this.doorController != null) return;
        this.doorController = transform.parent.GetComponent<DoorController>();
        Debug.Log(transform.name + ": LoadDoorController()", gameObject);
    }

    public void OpenDoor()
    {
        doorController._animator.SetBool("isOpen", true);
    }
}