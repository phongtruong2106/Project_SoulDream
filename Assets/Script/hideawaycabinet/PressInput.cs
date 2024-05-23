using UnityEngine;

public class PressInput : NewMonoBehaviour
{
    [SerializeField] protected hideawayCabinetController hideawayCabinetController;
    [SerializeField] protected GameObject ObjectCheckPlayerInSite;   
    [SerializeField] protected PlayerControler playerControler;   
    protected bool isCanPress;
 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadhideawayCabinetController();
        this.LoadPlayerController();
    }

    private void Update()
    {
        this.InputOpenHC();
        this.CloseHC();
    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }
    protected virtual void LoadhideawayCabinetController()
    {
        if(this.hideawayCabinetController != null) return;
        this.hideawayCabinetController = transform.parent.GetComponent<hideawayCabinetController>();
        Debug.Log(transform.name + ": LoadhideawayCabinetController()", gameObject);
    }

    protected virtual void InputOpenHC()
    {
        if(hideawayCabinetController._checkPlayer.IsPlayer)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                hideawayCabinetController._animator.SetBool("Open", true);
                
            }
            ObjectCheckPlayerInSite.gameObject.SetActive(true);
            playerControler._objectCrouch.isPlayerInSite = false;
        }
    }
    protected virtual void CloseHC()
    {
        if(hideawayCabinetController._checkPlayerInSite.isPlayerInSite)
        {
            
            CloseCabinet();
            this.isCanPress = true;
        }
        if(this.isCanPress)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                hideawayCabinetController._checkPlayerInSite.isPlayerInSite = false;
                this.OpenCabinet();
                this.isCanPress = false;
                this.ObjectCheckPlayerInSite.SetActive(false);
            }
        }
        
    }

    protected virtual void CloseCabinet()
    {
        hideawayCabinetController._animator.SetBool("CLose", true);
        hideawayCabinetController._animator.SetBool("Open", false);
    }

    protected virtual void OpenCabinet()
    {
        hideawayCabinetController._animator.SetBool("Open", true);
        hideawayCabinetController._animator.SetBool("CLose", false);
    }
}