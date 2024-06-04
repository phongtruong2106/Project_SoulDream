using UnityEngine;

public class Item : NewMonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    public ItemSO _itemSO => itemSO;
    protected ItemEvent itemEvent;
    protected Inventory inventory;

    protected Rigidbody rg_Body;
    
    protected override void Start()
    {
        rg_Body = GetComponent<Rigidbody>();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemEvent();
        this.LoadInventory();
    }

    protected void Update()
    {
        this.PressToGrab();
        this.ChangeIskinematic();
    }
    protected virtual void LoadItemEvent()
    {
        if(this.itemEvent!= null) return;
        this.itemEvent = GetComponentInChildren<ItemEvent>();
        Debug.Log(transform.name + ":  LoadItemEvent()", gameObject);
    }

    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = FindAnyObjectByType<Inventory>();
        Debug.Log(transform.name + ":  LoadInventory()", gameObject);
    }

    private void OnMouseDown()
    {
        Inventory.Instance.AddItem(this);
    }

    protected virtual void PressToGrab()
    {
        if (Input.GetKeyDown(KeyCode.H) && itemEvent.IsChecktoGrab)
        {
            Inventory.Instance.AddItem(this);
        }
    }

    protected virtual void ChangeIskinematic()
    {
        if(!inventory.IsGrab)
        {
            rg_Body.isKinematic = false;
        }
        else if(inventory.IsGrab)
        {
            rg_Body.isKinematic = true;
        }
    }
}