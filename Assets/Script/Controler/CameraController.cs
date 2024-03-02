using Unity.Mathematics;
using UnityEngine;

public class CameraController : NewMonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected Vector3 targetRotationAngles;
    [SerializeField] public float defaultZoom;
    public float _defaultZoom => defaultZoom;
    [SerializeField] public float zoom;
    [SerializeField] protected float zOffset;
    public float xOffset;
    public float yOffset;
    public float xRosOffset;
    public float yRosOffset;
    
    public float followSpeed = 1;
    public float defaultxOffset;
    public float defaultyOffset;
    public float defaulFollowSpeed = 1;

    protected override void Start()
    {
        base.Start();
        zoom = defaultZoom;
        xOffset = defaultxOffset;
        yOffset = defaultyOffset;
        followSpeed = defaulFollowSpeed;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.loadPlayerCharacter();
    }

    protected virtual void loadPlayerCharacter()
    {
        if(this.player != null) return;
        this.player = FindAnyObjectByType<CharacterController>().gameObject;
        Debug.Log(transform.name + ": LoadCharacterController()", gameObject);
    }

    protected void Update()
    {
        this.Position();
        this.Rotation();
    }

    protected virtual void Position()
    {
        targetPosition = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, zoom);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    protected virtual void Rotation()
    {
        targetRotationAngles = new Vector3(player.transform.position.x + xRosOffset, player.transform.position.y + yRosOffset, player.transform.position.z);
        transform.rotation = Quaternion.Euler(targetRotationAngles);
    }
}