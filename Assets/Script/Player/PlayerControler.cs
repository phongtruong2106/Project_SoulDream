using UnityEngine;

public class PlayerControler : NewMonoBehaviour
{
    [Header("Player Controller")]
    public static PlayerControler instance;
    [SerializeField] protected ObjectMovement objectMovement;
    public ObjectMovement _objectMovement => objectMovement;
    [SerializeField] protected ObjectMoveFoward objectMoveFoward;
    public ObjectMoveFoward _objectMoveFoward => objectMoveFoward;
    [SerializeField] protected ObjectLedgeClimb objectLedgeClimb;
    public ObjectLedgeClimb _objectLedgeClimb => objectLedgeClimb;
    [SerializeField] protected ObjectLedgeDetection objectLedgeDetection;
    public ObjectLedgeDetection _objectLedgeDetection => objectLedgeDetection;
    [SerializeField] protected ObjectPushDetected objectPushDetected;
    public ObjectPushDetected _objectPushDetected => objectPushDetected;
    [SerializeField] protected Inventory inventory;
    public Inventory _inventory => inventory;
    protected override void Awake()
    {
        base.Awake();
        if(PlayerControler.instance != null) Debug.LogError("Only 1 GameControler allow to ");
        PlayerControler.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectMovement();
        this.LoadObjectLedgeClimb();
        this.LoadObjectLedgeDetection();
        this.LoadObjectPushDetected();
        this.LoadObjectMoveFoward();
        this.LoadInventory();
    }

    protected virtual void LoadObjectMovement()
    {
        if(this.objectMovement != null) return;
        this.objectMovement = GetComponentInChildren<ObjectMovement>();
        Debug.Log(transform.name + ": LoadObjectMovement()", gameObject);
    }

    protected virtual void LoadObjectMoveFoward()
    {
        if(this.objectMoveFoward != null) return;
        this.objectMoveFoward = GetComponentInChildren<ObjectMoveFoward>();
        Debug.Log(transform.name + ": LoadObjectMoveFoward()", gameObject);
    }

    protected virtual void LoadObjectLedgeClimb()
    {
        if(this.objectLedgeClimb != null) return;
        this.objectLedgeClimb = GetComponentInChildren<ObjectLedgeClimb>();
        Debug.Log(transform.name + ": LoadObjectLedgeClimb();", gameObject);
    }

    protected virtual void LoadObjectLedgeDetection()
    {
        if(this.objectLedgeDetection!= null) return;
        this.objectLedgeDetection = transform.GetComponentInChildren<ObjectLedgeDetection>();
        Debug.Log(transform.name + ": LoadObjectLedgeDetection()", gameObject);
    }

    protected virtual void LoadObjectPushDetected()
    {
        if(this.objectPushDetected != null) return;
        this.objectPushDetected = transform.GetComponentInChildren<ObjectPushDetected>();
        Debug.Log(transform.name + ": LoadObjectPushDetected()", gameObject);
    }
    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = FindAnyObjectByType<Inventory>();
        Debug.Log(transform.name + ": LoadInventory()", gameObject);
    }
}