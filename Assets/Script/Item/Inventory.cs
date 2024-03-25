using System.Collections.Generic;
using UnityEngine;

public class Inventory : NewMonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] protected Item item;
 
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
   public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log("Item added to inventory: " + item._itemSO.itemName);
    }
}