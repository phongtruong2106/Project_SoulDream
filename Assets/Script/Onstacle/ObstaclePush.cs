using UnityEngine;

public class ObstaclePush : NewMonoBehaviour
{
    [SerializeField] protected float forceMagnitude;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        // this.LoadRigidbody();
    }

    // protected virtual void LoadRigidbody()
    // {
    //     if(this.rigidbody != null) return;
    //     this.rigidbody = transform.parent.parent.GetComponentInChildren<Rigidbody>();
    //     Debug.Log(transform.name + ": LoadRigidbody()", gameObject);
    // }
    protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if(rigidbody != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
