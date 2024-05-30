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

    protected void FixedUpdate()
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
        if (Input.GetKeyDown(KeyCode.G) && itemEvent.IsChecktoGrab)
        {
            Inventory.Instance.AddItem(this);
        }
    }
}