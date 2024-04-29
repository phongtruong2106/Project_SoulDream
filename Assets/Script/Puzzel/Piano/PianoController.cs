using UnityEngine;

public class PianoController : NewMonoBehaviour
{
    protected NotificationPiano nofiticationPiano;
    public NotificationPiano _notificationPiano => nofiticationPiano;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNotificationPiano();
    }

    protected virtual void LoadNotificationPiano()
    {
        if(this.nofiticationPiano != null) return;
        this.nofiticationPiano = GetComponentInChildren<NotificationPiano>();
        Debug.Log(transform.name + ": LoadNotificationPiano()", gameObject);
    }

    
}