using UnityEngine;

public class Item : NewMonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    public ItemSO _itemSO => itemSO;
    protected ItemEvent itemEvent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemEvent();
    }

    protected void Update()
    {
        this.PressToGrab();
    }
    protected virtual void LoadItemEvent()
    {
        if(this.itemEvent!= null) return;
        this.itemEvent = GetComponentInChildren<ItemEvent>();
        Debug.Log(transform.name + ":  LoadItemEvent()", gameObject);
    }

    private void OnMouseDown()
    {
        Inventory.Instance.AddItem(this);
    }

    protected virtual void PressToGrab()
    {
        if (Input.GetKeyDown(KeyCode.H) && itemEvent.IsChecktoGrab)
        {
            Debug.Log("Attempting to add item to inventory", gameObject);
            Inventory.Instance.AddItem(this);
        }
    }
}