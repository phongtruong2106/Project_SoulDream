using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyHolder : NewMonoBehaviour
{
    public event EventHandler OnKeysChanged;
    public static KeyHolder instance;
    private List<Key.KeyType> keyList;

    [SerializeField] protected UIController uIController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
    }

    protected virtual void Update()
    {
       // this.uIController._uI_Dialogue.Invoke("StopDialogue", 4f);
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController!= null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }

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

    protected virtual void CheckForFKey(Collider collider)
    {
        if (Input.GetKey(KeyCode.F))
        {
            HandleFKeyPressed(collider);
        }
    }

    protected virtual void HandleFKeyPressed(Collider collider)
    {
        this.Key(collider);
        this.KeyDoor(collider);
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        CheckForFKey(other);
    }    
    private void OnTriggerEnter(Collider other)
    {
        this.CheckKeyOn(other);
        this.CheckKeyDoorOn(other);
    }

    private void OnTriggerExit(Collider other)
    {
        this.CheckKeyOut(other);
        this.CheckKeyDoorOut(other);
    }
    protected virtual void Key(Collider collider)
    {
        Key key = collider.GetComponent<Key>();
        if(key != null) 
        {
            AddKey(key.GetKeyType());
            Destroy(key.transform.parent.gameObject);
        }
        else
        {
            this.UnHideObje();
        }
    }

    protected virtual void KeyDoor(Collider collider)
    {
        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {
            if(ContainsKey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
            else
            {
                uIController._dialogueNew.OpenDialogue();
            }
        }
        else
        {
            this.UnHideObje();
        }
    }
    protected virtual void CheckKeyOn(Collider collider)
    {
        Key key = collider.GetComponent<Key>();
        if(key != null) 
        {
            this.HideObj();
            uIController._uI_PressButton._text_ObjPress.text = "Press F to pick up";
        }
    }
    protected virtual void CheckKeyOut(Collider collider)
    {
        Key key = collider.GetComponent<Key>();
        if(key != null) 
        {
            this.UnHideObje();
        }
    }
    protected virtual void CheckKeyDoorOn(Collider collider)
    {
        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {   
            this.HideObj();
            uIController._uI_PressButton._text_ObjPress.text = "Press F to open";
        }
    }
    protected virtual void CheckKeyDoorOut(Collider collider)
    {
        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {
            this.UnHideObje();
        }
    }

    protected virtual void HideObj()
    {
        uIController._uI_PressButton.OpenObjPress();
    }
    protected virtual void UnHideObje()
    {
        uIController._uI_PressButton.CloseObjPress();
    }
}