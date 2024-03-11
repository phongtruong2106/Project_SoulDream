using UnityEngine;

public class DialogueNew : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] protected TextAsset inkJson;
    
    public virtual void OpenDialogue()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJson);
    }

    public virtual void ExitDialogue()
    {
        DialogueManager.GetInstance().ExitDialogueMode();
    }
}