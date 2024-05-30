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
    [SerializeField] private Transform postionHandTargetGrabItem;
    [SerializeField] protected bool isGrab = true;
    public bool IsGrab => isGrab;
    public Dictionary<ItemType, Item> ItemsDictionary => itemDictionary;
    private Item currentItemInSlot;
    protected bool isFull = false;
    
 
    private static Inventory instance;
    public static Inventory Instance => instance;

    protected void Update()
    {
        this.PressToDrop();
    }

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
        if(currentItemInSlot == null)
        {
            Debug.Log("AOa");
            itemDictionary[newItem._itemSO.itemType] = newItem;
            newItem.transform.SetParent(itemHolder);
            // newItem.transform.localPosition = Vector3.zero; 
            uIController._uIGame._spriteItem.sprite = newItem._itemSO.image;
            //newItem.transform.gameObject.SetActive(false);
            newItem.transform.position = new Vector3 (postionHandTargetGrabItem.position.x, postionHandTargetGrabItem.position.y, postionHandTargetGrabItem.position.z);
            currentItemInSlot = newItem;
            isGrab = true;
        
        }
       
       
    }
    
    protected virtual void PressToDrop()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            this.DropCurrentItem();
        }
    }

    protected virtual void DropCurrentItem()
    {
        if (currentItemInSlot != null)
        {
            currentItemInSlot.transform.gameObject.SetActive(true);
            currentItemInSlot.transform.SetParent(null);
            itemDictionary.Remove(currentItemInSlot._itemSO.itemType);
            uIController._uIGame._spriteItem.sprite = null;
            currentItemInSlot = null;
            OnKeysChanged?.Invoke(this, EventArgs.Empty);
            this.isGrab = false;
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
}