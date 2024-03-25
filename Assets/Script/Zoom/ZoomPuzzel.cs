using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPuzzel : ZoomPressKey
{
    protected override void PressKeyZoom()
    {
        base.PressKeyZoom();
        if(isZone)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.DefaultZoomTarget();
            }
        }
    }
}
