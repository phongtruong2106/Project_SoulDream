using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Inventory : NewMonoBehaviour
{
    public event EventHandler OnKeysChanged;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform itemHolder;
    [SerializeField] protected UIController uIController;
    [SerializeField] private Dictionary<ItemType, Item> itemDictionary = new Dictionary<ItemType, Item>();

    public Dictionary<ItemType, Item> ItemsDictionary => itemDictionary;
    private Item currentItemInSlot;
    
 
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
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController();", gameObject);
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
        newItem.transform.parent.SetParent(itemHolder);
        // newItem.transform.localPosition = Vector3.zero; 
        uIController._uIGame._spriteItem.sprite = newItem._itemSO.image;
        //newItem.transform.parent.gameObject.SetActive(false);
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
            uIController._uIGame._spriteItem.sprite = null;
            OnKeysChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}