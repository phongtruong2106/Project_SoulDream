using UnityEngine;

public class ObjectLedgeDetection : NewMonoBehaviour
{
    [Header("ObjectLedgeDetection")]
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsGround;
    public ObjectLedgeClimb objectLedgeClimb;
    public PlayerControler playerControler;
    //[SerializeField] protected bool ledgeDetecteds;
    [SerializeField] private bool canDetected;

    protected override void Start() {
        // canDetected = true;
    }

    private void Update() {
        this.IsCanDetected();
    }   

    protected virtual void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Box")) {
            canDetected = false;
        }
    }

    protected virtual void OnTriggerExit(Collider collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Box")) {
            canDetected = true;
        }
    }

    protected virtual void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    protected virtual void IsCanDetected() {
        if (canDetected) {
           Collider[] colliders = Physics.OverlapSphere(transform.position, radius, whatIsGround);
            objectLedgeClimb.ledgeDetected = colliders.Length > 0;
        } else {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, whatIsGround);
            objectLedgeClimb.ledgeDetected = colliders.Length < 0;
        }
    }
}
