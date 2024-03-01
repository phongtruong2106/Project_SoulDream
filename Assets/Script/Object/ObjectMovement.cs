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
    public bool isGrounded;
    public bool isMove = true;

    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected float gravity;
    [SerializeField] protected float jumpHeight;

    protected float moveX;
    public float _moveX => moveX;
    protected float moveY;
    public float _moveY => moveY;
}
