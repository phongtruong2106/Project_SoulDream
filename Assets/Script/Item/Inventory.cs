using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : NewMonoBehaviour
{
    public event EventHandler OnKeysChanged;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Dictionary<ItemType, Item> itemDictionary = new Dictionary<ItemType, Item>();

    public Dictionary<ItemType, Item> ItemsDictionary => itemDictionary;
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
            currentItemInSlot.transform.parent.gameObject.SetActive(true);
            if (itemDictionary.ContainsKey(currentItemInSlot._itemSO.itemType))
            {
                itemDictionary.Remove(currentItemInSlot._itemSO.itemType);
            }
        }
        itemDictionary[newItem._itemSO.itemType] = newItem;
        newItem.transform.parent.gameObject.SetActive(false);
        currentItemInSlot = newItem;
    }

   public void RemoveItemWithGameObject(ItemType itemType)
    {
        if (itemDictionary.ContainsKey(itemType))
        {
            Item item = itemDictionary[itemType];
            if (item != null && item.gameObject != null)
            {
                Destroy(item.transform.parent.gameObject);
            }
            ItemsDictionary.Remove(itemType);

            OnKeysChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}