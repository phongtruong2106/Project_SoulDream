using UnityEngine;

public class CameraTrigger : NewMonoBehaviour
{
    [SerializeField] protected float zoom;
    [SerializeField] protected float xoffset;
    [SerializeField] protected float yOffset;
    [SerializeField] protected float followSpeed;
 
    [SerializeField] protected CameraController cameraController;

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
        } 

    }
}