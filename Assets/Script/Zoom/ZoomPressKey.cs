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
            }           
        }   
    }
    
    protected virtual void ZoomTarget()
    {
        cameraController.zoom = zoom;
        cameraController.xOffset = xoffset;
        cameraController.yOffset = yOffset;
        cameraController.followSpeed = followSpeed;
        cameraController.xRosOffset = this.xRosOffset;
        cameraController.yRosOffset = this.yRosOffset;
        if(this.targetPoint != null)
        {
            cameraController.targetDefaul = this.targetPoint;
        }
        else
        {
            cameraController.targetDefaul = cameraController.targetPlayer;
        }
    }
}