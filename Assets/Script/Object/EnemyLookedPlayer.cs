using UnityEngine;

public class EnemyLookedPlayer : NewMonoBehaviour
{
    [SerializeField] protected float viewDistance = 10.0f; 
    [SerializeField] protected float viewAngle = 45.0f; 
    [SerializeField] private Transform coneOrigin;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private string playerTag = "Player"; 

    protected void Update()
    {
        this.CheckForPlayer();
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
                            Debug.Log("Player detected");
                        }
                    }
                }
            }
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