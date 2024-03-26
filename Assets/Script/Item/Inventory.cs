using System.Collections.Generic;
using UnityEngine;

public class Inventory : NewMonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Dictionary<ItemType, int> itemDictionary = new Dictionary<ItemType, int>();
    public Dictionary<ItemType, int> ItemsDictionary => itemDictionary;
    private Item currentItemInSlot;
    private KeyHolder keyHolder;
 
    private static Inventory instance;
    public static Inventory Instance => instance;

    protected override void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void AddItem(Item newItem)
    {
        if (currentItemInSlot != null)
        {
           // Destroy(currentItemInSlot.transform.parent.gameObject);
            currentItemInSlot.transform.parent.gameObject.SetActive(true);
            itemDictionary.Remove(currentItemInSlot._itemSO.itemType);
        }
        
        itemDictionary[newItem._itemSO.itemType] = 1;
        newItem.transform.parent.gameObject.SetActive(false);

        currentItemInSlot = newItem;
    }
}