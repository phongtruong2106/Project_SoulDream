using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : NewMonoBehaviour
{
    [Header("Object Movement")]
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float runSpeed;
    
    protected Vector3 moveDirection;
    protected Vector3 velocity;
    [SerializeField] protected bool isGrounded;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected float gravity;
    [SerializeField] protected float jumpHeight;
}
