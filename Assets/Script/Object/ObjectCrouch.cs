using UnityEngine;

public class ObjectCrouch : NewMonoBehaviour
{
    [SerializeField] protected bool isCrouch = false;
    protected PlayerControler playerControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    private void Update() {
        this.CheckInput();
        this.Crouch();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.parent.GetComponent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerController()", gameObject);
    }

    protected virtual void Crouch()
    {
        if(this.isCrouch)
        {
            playerControler._animator.SetBool("IsCrouch", true);
        }
        else
        {
            playerControler._animator.SetBool("IsCrouch", false);
        }
    }

    protected virtual void CheckInput()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            this.isCrouch = true;
        }
        else
        {
            this.isCrouch = false;
        }
    }
}