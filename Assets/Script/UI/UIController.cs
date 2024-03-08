using TMPro;
using UnityEngine;

public class UIController : NewMonoBehaviour
{
    [SerializeField] protected UI_Dialogue uI_Dialogue;
    public UI_Dialogue _uI_Dialogue => uI_Dialogue;
    [SerializeField] protected UI_PressButton uI_PressButton;
    public UI_PressButton _uI_PressButton => uI_PressButton;
    [SerializeField] protected UI_KeyHolder uI_KeyHolder;
    public UI_KeyHolder _uI_KeyHolder => uI_KeyHolder;
    [SerializeField] protected DialogueNew dialogueNew;
    public DialogueNew _dialogueNew => dialogueNew;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIDialogue();
        this.LoadUIPressButton();
        this.LoadUIKeyHolder();
        this.LoadDialogueNew();
    }

    protected virtual void LoadUIDialogue()
    {
        if(this.uI_Dialogue != null) return;
        this.uI_Dialogue = GetComponentInChildren<UI_Dialogue>();
        Debug.Log(transform.name + ": LoadUIDialogue()", gameObject);
    }

    protected virtual void LoadUIPressButton()
    {
        if(this.uI_PressButton != null) return;
        this.uI_PressButton = GetComponentInChildren<UI_PressButton>();
        Debug.Log(transform.name + ": LoadUIPressButton()", gameObject);
    }

    protected virtual void LoadUIKeyHolder()
    {
        if(this._uI_KeyHolder != null) return;
        this.uI_KeyHolder = GetComponentInChildren<UI_KeyHolder>();
        Debug.Log(transform.name + ": LoadUIKeyHolder()", gameObject);
    }
    protected virtual void LoadDialogueNew()
    {
        if(this.dialogueNew != null) return;
        this.dialogueNew = GetComponentInChildren<DialogueNew>();
        Debug.Log(transform.name + ": LoadDialogueNew()", gameObject);
    }
}
