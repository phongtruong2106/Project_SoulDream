using UnityEngine;

public class CameraController : NewMonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected Vector3 target;
    
    [SerializeField] public float defaultZoom;
    public float _defaultZoom => defaultZoom;
    [SerializeField] public float zoom;
    public float xOffset;
    public float yOffset;
    public float followSpeed = 1;
    public float defaultxOffset;
    public float defaultyOffset;
    public float defaulFollowSpeed = 1;

    protected override void Start()
    {
        base.Start();
        player  = FindAnyObjectByType<CharacterController>().gameObject;
        zoom = defaultZoom;
        xOffset = defaultxOffset;
        yOffset = defaultyOffset;
        followSpeed = defaulFollowSpeed;
    }

    protected void Update()
    {
        target = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, zoom);

        transform.position = Vector3.Lerp(transform.position, target, followSpeed * Time.deltaTime);
    }

}