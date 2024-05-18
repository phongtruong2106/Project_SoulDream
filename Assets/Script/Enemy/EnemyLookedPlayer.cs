using UnityEngine;

public class EnemyLookedPlayer : NewMonoBehaviour
{
    [SerializeField] protected float viewDistance = 10.0f; 
    public float viewAngle = 45.0f; 
    [SerializeField] private Transform coneOrigin;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private string playerTag = "Player"; 
    [SerializeField] protected Transform objPlayer;
    protected EnemyController enemyController;
    protected bool isLookedPlayer = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }
    protected void Update()
    {
        this.CheckForPlayer();
        this.FollowPlayer();
    }
    protected virtual void LoadEnemyController()
    {
        if(this.enemyController != null) return;
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyController()", gameObject);
    }
    private void CheckForPlayer()
    {
        Collider[] playersInRange = Physics.OverlapSphere(coneOrigin.position, viewDistance, playerLayerMask);
        foreach (var player in playersInRange)
        {
            if (player.CompareTag(playerTag))
            {
                Vector3 directionToPlayer = (player.transform.position - coneOrigin.position).normalized;
                float angleToPlayer = Vector3.Angle(coneOrigin.forward, directionToPlayer);
                
                if (angleToPlayer < viewAngle / 2)
                {
                    if (Physics.Raycast(coneOrigin.position, directionToPlayer, out RaycastHit hit, viewDistance, playerLayerMask))
                    {
                        if (hit.collider.CompareTag(playerTag))
                        {
                            this.isLookedPlayer = true;
                            
                        }
                    }
                }
            }
        }
    }


    protected virtual void FollowPlayer()
    {
        if(this.isLookedPlayer)
        {
            enemyController._enemyMovement.objectPos = objPlayer;
            enemyController._enemyMovement.MoveTowardsPlayer();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Matrix4x4 cubeTransform = Matrix4x4.TRS(coneOrigin.position, coneOrigin.rotation, Vector3.one);
        Gizmos.matrix = cubeTransform;
        Gizmos.DrawFrustum(Vector3.zero, viewAngle, viewDistance, 0.0f, 1.0f);
    }
}