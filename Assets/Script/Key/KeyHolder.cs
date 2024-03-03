using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyHolder : NewMonoBehaviour
{
    public event EventHandler OnKeysChanged;
    public static KeyHolder instance;
    private List<Key.KeyType> keyList;

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    protected override void Awake()
    {
        base.Awake();
        keyList = new List<Key.KeyType>();
        if(KeyHolder.instance != null) Debug.LogError("Only 1 KeyHolder allow to ");
        KeyHolder.instance = this;
    }
    protected virtual void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Add key: " + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    protected virtual bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Key key = other.GetComponent<Key>();
        if(key != null) 
        {
            AddKey(key.GetKeyType());
            Destroy(key.transform.parent.gameObject);
        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {
            if(ContainsKey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
        }
    }
}