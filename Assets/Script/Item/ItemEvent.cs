using UnityEngine;

public class ItemEvent : NewMonoBehaviour
{
    [Header("Item Event")]
    [SerializeField] protected string textBox;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected UIController uIController;
    [Header("Item Check child Holder")]
    [SerializeField] protected ItemCheck itemCheck;
    [SerializeField] protected Object obj_ItemCheck;
    protected bool isChecktoGrab = false;
    public bool IsChecktoGrab => isChecktoGrab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadItemCheck();
        this.LoadUIController();
    }

    protected void Update()
    {
        this.CheckIsPlayer();
    }

    protected virtual void LoadItemCheck()
    {
        if(this.itemCheck != null) return;
        this.itemCheck = GetComponentInChildren<ItemCheck>();
        Debug.Log(transform.name + ":  LoadItemCheck()", gameObject);
    }

    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = FindAnyObjectByType<Inventory>();
        Debug.Log(transform.name + ":  LoadInventory()", gameObject);
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ":  LoadUIController()", gameObject);
    }

    protected virtual void CheckIsPlayer()
    {
        if(!inventory.IsGrab)
        {
            if(itemCheck.isPlayer)
            {
                uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.SetActive(true);
                uIController._uI_PressButtonItem._text_ObjPress.text = textBox;
                this.isChecktoGrab = true;
            }
            else
            {
                uIController._uI_PressButtonItem.UI_pressButtonItem.gameObject.SetActive(false);
                this.isChecktoGrab = false;
            }
        }
        
    }

 
}