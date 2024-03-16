using UnityEngine;

public class ZoomOnClick : Zoom
{   
    [Header("Zoom OnClick")]
    protected bool isClick;
    protected override void Start() {
        this.isClick = false;
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

    protected virtual void OnMouseDown()
    {
        
        this.isClick = true;
        Debug.Log("adsad");
        //this.ZoomTarget();
    }
    
}