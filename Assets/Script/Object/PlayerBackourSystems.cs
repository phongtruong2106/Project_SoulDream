using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackourSystems : NewMonoBehaviour
{
    [SerializeField] protected bool _isObj;
    [SerializeField] protected Vector3 _ObjPosition;
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.gameObject.transform.tag == "ClimbObj")
        {
            _isObj = true;
            _ObjPosition = other.transform.gameObject.transform.GetComponent<Transform>().position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.gameObject.transform.tag == "ClimbObj")
        {
            _isObj = false; 
        }
    }
}
