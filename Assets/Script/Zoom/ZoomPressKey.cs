using UnityEngine;

public class ZoomPressKey : Zoom
{
    [Header("Zoom Press Key")]
    protected bool isZoom;
    protected bool isZone;

    private void Update() 
    {
        this.PressKeyZoom();
    }
    protected override void Start()
    {
        base.Start();
        this.isZoom = false;
        this.isZone = false;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            this.isZone = true;
        }
        
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            this.isZone = false;
            this.DefaultZoomTarget();
        }
        
    }

    protected virtual void PressKeyZoom()
    {
        if(Input.GetKey(KeyCode.F))
        {
            if(isZone)
            {
                this.ZoomTarget();
                this.gameManager._hideMouse.isHide = true;
            }           
        }   
    }
}