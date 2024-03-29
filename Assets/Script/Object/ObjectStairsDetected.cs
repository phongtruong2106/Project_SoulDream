using UnityEngine;

public class ObjectStairsDetected : NewMonoBehaviour
{
    [SerializeField] private string stairsTag = "Stairs";
    [SerializeField]protected bool isStairs = false;
    public bool _isStairs => isStairs;

    protected virtual void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag(stairsTag)) {
            isStairs = false;
        }
    }

    protected virtual void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag(stairsTag)) {
            isStairs = true;
        }  
    }

}