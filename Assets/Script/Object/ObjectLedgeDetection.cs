using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLedgeDetection : MonoBehaviour
{
    [Header("ObjectLedgeDetection")]
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask whatIsGround;
    public ObjectLedgeClimb objectLedgeClimb;
    public PlayerControler playerControler;
    [SerializeField] private bool canDetected = true;

    private void Start() {
        canDetected = true;
    }
    private void Update()
    {
        if(canDetected)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, whatIsGround);
            objectLedgeClimb.ledgeDetected = colliders.Length > 0;
        }
          
    }   

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canDetected = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canDetected = true;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
