using UnityEngine;

public class PlayerControler : NewMonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] protected ObjectMovement objectMovement;
    public ObjectMovement _objectMovement => objectMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectMovement();
    }

    protected virtual void LoadObjectMovement()
    {
         if(this.objectMovement != null) return;
        this.objectMovement = GetComponentInChildren<ObjectMovement>();
        Debug.Log(transform.name + ": LoadObjectMovement()", gameObject);
    }
}