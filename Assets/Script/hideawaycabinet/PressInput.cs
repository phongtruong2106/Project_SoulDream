using UnityEngine;

public class PressInput : NewMonoBehaviour
{
    [SerializeField] protected hideawayCabinetController hideawayCabinetController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadhideawayCabinetController();
    }

    private void Update()
    {
        this.InputOpenHC();
        this.CloseHC();
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
        }
    }
    protected virtual void CloseHC()
    {
        if(hideawayCabinetController._checkPlayerInSite.IsPlayerInSite)
        {
            hideawayCabinetController._animator.SetBool("CLose", true);
            hideawayCabinetController._animator.SetBool("Open", false);
            if(Input.GetKeyDown(KeyCode.E))
            {
                hideawayCabinetController._animator.SetBool("Open", true);
                hideawayCabinetController._animator.SetBool("CLose", false);
            }
        }
    }
}