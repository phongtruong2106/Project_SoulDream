using UnityEngine;

public class AnimationEvent : NewMonoBehaviour
{
    [SerializeField] protected PlayerControler playerControler;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerControler();
    }

    protected virtual void LoadPlayerControler()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.parent.GetComponent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerControler()", gameObject);
    }
    public void HandleLedgeClimbOver()
    {
       playerControler._objectLedgeClimb.LedgeClimbOver();
    }
}