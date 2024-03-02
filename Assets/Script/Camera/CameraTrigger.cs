using UnityEngine;

public class CameraTrigger : NewMonoBehaviour
{
    [SerializeField] protected float zoom;
    [SerializeField] protected float xoffset;
    [SerializeField] protected float yOffset;
    [SerializeField] protected float xRosOffset;
    [SerializeField] protected float yRosOffset;
    [SerializeField] protected float followSpeed;
 
    [SerializeField] protected CameraController cameraController;
    [SerializeField] protected Transform targetPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCameraController();
    }

    protected virtual void LoadCameraController()
    {
        if(this.cameraController != null) return;
        this.cameraController = FindAnyObjectByType<CameraController>();
        Debug.Log(transform.name + ": LoadCameraController();", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            cameraController.zoom = zoom;
            cameraController.xOffset = xoffset;
            cameraController.yOffset = yOffset;
            cameraController.followSpeed = followSpeed;
            cameraController.xRosOffset = this.xRosOffset;
            cameraController.yRosOffset = this.yRosOffset;

        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cameraController.zoom = cameraController._defaultZoom;
            cameraController.xOffset = cameraController.defaultxOffset;
            cameraController.yOffset = cameraController.defaultyOffset;
            cameraController.followSpeed = cameraController.defaulFollowSpeed;
            cameraController.xRosOffset = 0;
            cameraController.yRosOffset = 0;
        } 

    }
}