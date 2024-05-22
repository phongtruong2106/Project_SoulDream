using UnityEngine;

public class ObjectCrouch : NewMonoBehaviour
{
    [SerializeField] protected bool isCrouch = false;
    protected PlayerControler playerControler;
    private float lastControlClickTime = 0f;
    private float doubleClickThreshold = 0.3f;
    

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
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            float timeSinceLastClick = Time.time - lastControlClickTime;
            if (timeSinceLastClick <= doubleClickThreshold)
            {
                this.isCrouch = false;
            }
            else
            {
                this.isCrouch = true;
            }
            lastControlClickTime = Time.time;
        }
    }
}