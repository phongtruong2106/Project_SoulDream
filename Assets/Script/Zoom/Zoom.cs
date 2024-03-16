using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : NewMonoBehaviour
{
    [Header("Zoom")]
    [SerializeField] protected float zoom;
    [SerializeField] protected float xoffset;
    [SerializeField] protected float yOffset;
    [SerializeField] protected float xRosOffset;
    [SerializeField] protected float yRosOffset;
    [SerializeField] protected float followSpeed;
 
    [SerializeField] protected CameraController cameraController;
    [SerializeField] protected GameObject targetPoint;

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
}
