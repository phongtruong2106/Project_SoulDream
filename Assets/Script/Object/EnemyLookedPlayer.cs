using UnityEngine;

public class EnemyLookedPlayer : NewMonoBehaviour
{
        [SerializeField] protected float viewDistance = 10.0f; 
        [SerializeField] protected float viewAngle = 45.0f; 
        [SerializeField] private Transform coneOrigin;







    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Matrix4x4 cubeTransform = Matrix4x4.TRS(coneOrigin.position, coneOrigin.rotation, Vector3.one);
        Gizmos.matrix = cubeTransform;
        Gizmos.DrawFrustum(Vector3.zero, viewAngle, viewDistance, 0.0f, 1.0f);
    }
}