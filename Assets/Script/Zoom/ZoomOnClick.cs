using UnityEngine;

public class ZoomOnClick : Zoom
{   
    [Header("Zoom OnClick")]
    [SerializeField] protected bool isClick;
    protected override void Start() {
        this.isClick = false;
    }

    protected void Update()
    {
        this.CheckClick();
        this.PressKeyExitZoom();
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
    }

    protected virtual void CheckClick()
    {
        if(isClick)
        {
            this.ZoomTarget();
        }
    }
    protected virtual void PressKeyExitZoom()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            this.DefaultZoomTarget();
            this.isClick = false;
        }
    }
}