using TMPro;
using UnityEngine;

public class UI_PressButton : NewMonoBehaviour
{
    public static UI_PressButton instance;
    [SerializeField] protected GameObject ui_ObjPress;
    [SerializeField] protected TextMeshProUGUI text_ObjPress;
    public TextMeshProUGUI _text_ObjPress => text_ObjPress;

    protected override void Awake()
    {
        base.Awake();
        if(UI_PressButton.instance != null) Debug.LogError("Only 1 UIController allow to ");
        UI_PressButton.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        CloseObjPress();
    }

    public virtual void OpenObjPress()
    {
        ui_ObjPress.gameObject.SetActive(true);
    }

    public virtual void CloseObjPress()
    {
        ui_ObjPress.gameObject.SetActive(false);
    }
}