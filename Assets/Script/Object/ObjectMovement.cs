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
    public bool isMovel = true;

    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected float gravity;
    [SerializeField] protected float jumpHeight;

    protected float moveX;
    public float _moveX => moveX;
    protected float moveZ;
    public float _moveZ => moveZ;
    protected bool isCrouch = true;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.walkSpeed = 2;
        this.runSpeed = 7;
        this.isMove = true;
        this.groundCheckDistance = 0.2f;
        this.gravity = -9.81f;
        this.jumpHeight = 2;
    }

}
