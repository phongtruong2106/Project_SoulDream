using System;
using UnityEngine;

public class ObjectClimbingStairs : NewMonoBehaviour
{
    [SerializeField] protected PlayerControler playerControler;

    private void Update() {
        this.CheckIsStairs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler  = FindAnyObjectByType<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerController()", gameObject);
    }

    protected virtual void CheckIsStairs()
    {
        if(playerControler._objectStairsDetected._isStairs)
        {
            playerControler._animator.SetBool("IsStairs", true);
            playerControler._animator.SetBool("isJumping", false);
        }
        else
        {
            playerControler._animator.SetBool("IsStairs", false);
        }
    }
}