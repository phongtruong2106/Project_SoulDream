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
    private Dictionary<ItemType, Item> itemDictionary = new Dictionary<ItemType, Item>();
    public Dictionary<ItemType, Item> ItemsDictionary => itemDictionary;
    [SerializeField] private GameObject postionHandTargetGrabItem;
    [SerializeField] protected bool isGrab = true;
    public bool IsGrab => isGrab;
    private Item currentItemInSlot;
    protected bool isFull = false;
    
 
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

    private void Update()
    {
            this.PressToDrop();
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
            if (currentItemInSlot == null)
            {
                itemDictionary[newItem._itemSO.itemType] = newItem;
                newItem.transform.SetParent(itemHolder);
                uIController._uIGame._spriteItem.sprite = newItem._itemSO.image;
                newItem.transform.position = new Vector3(postionHandTargetGrabItem.transform.position.x, postionHandTargetGrabItem.transform.position.y ,postionHandTargetGrabItem.transform.position.z);
                currentItemInSlot = newItem;
                isGrab = true;
            }
            else
            {
                Debug.Log("Cannot add item, inventory slot is already full");
            }
    }

    protected virtual void DropCurrentItem()
    {
        if(currentItemInSlot != null)
        {
            itemDictionary.Remove(currentItemInSlot._itemSO.itemType);
            uIController._uIGame._spriteItem.sprite = null;
            currentItemInSlot.transform.SetParent(null);
            Vector3 dropPosition = postionHandTargetGrabItem.transform.position + postionHandTargetGrabItem.transform.forward * 1f;
            currentItemInSlot.transform.position = dropPosition;
            currentItemInSlot = null;
            OnKeysChanged?.Invoke(this, EventArgs.Empty);
            isGrab = false;
        }
    }

    
    protected virtual void PressToDrop()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            this.DropCurrentItem();
        }
    }

    
   public void RemoveItemWithGameObject(ItemType itemType)
    {
        if (itemDictionary.ContainsKey(itemType))
        {
            Item item = itemDictionary[itemType];
            if (item != null && item.gameObject != null)
            {
                Destroy(item.transform.gameObject);
            }
            ItemsDictionary.Remove(itemType);
            uIController._uIGame._spriteItem.sprite = null;
            OnKeysChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void LogItemCount()
    {
        Debug.Log("Current number of items in inventory: " + itemDictionary.Count);
    }
}