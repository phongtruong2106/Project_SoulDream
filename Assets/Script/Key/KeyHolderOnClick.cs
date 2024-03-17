using UnityEngine;
using UnityEngine.EventSystems;

public class KeyHolderOnClick : KeyHolder
{

    protected override void OnClickMouse()
    {
        base.OnClickMouse();
        LockManager.Instance.isPickKey = true;
    }


}