using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class KeyHolder : NewMonoBehaviour
{
    public event EventHandler OnKeysChanged;
    public static KeyHolder instance;
    public bool isOpen = true;
    private List<Key.KeyType> keyList;
    [SerializeField]private Camera mainCamera;
    [SerializeField] protected UIController uIController;
    public static KeyHolder Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<KeyHolder>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("KeyHolder");
                    instance = obj.AddComponent<KeyHolder>();
                }
            }
            return instance;
        }
    }
    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
    }
    protected override void Awake()
    {
        base.Awake();
        keyList = new List<Key.KeyType>();
        // if(KeyHolder.instance != null) Debug.LogError("Only 1 KeyHolder allow to ");
        // KeyHolder.instance = this;
    }
    private void Update() {
        this.OnClickMouse();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
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
        if (Input.GetKeyDown(KeyCode.F))
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

    protected virtual void OnClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                HandleClick(hit.collider.gameObject);
            }
        }
    }

    private void HandleClick(GameObject clickedObject)
    {
        Key key = clickedObject.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            LockManager.Instance.isPickKey = true;
            Destroy(key.transform.parent.gameObject);
        }
        else
        {
            UnHideObje();
        }
    }
}