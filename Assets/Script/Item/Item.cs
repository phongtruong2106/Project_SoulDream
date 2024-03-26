using UnityEngine;

public class Item : NewMonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    public ItemSO _itemSO => itemSO;

    private void OnMouseDown()
    {
        Inventory.Instance.AddItem(this);
    }

}