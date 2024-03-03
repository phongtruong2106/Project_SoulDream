using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : NewMonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        DoorAnim.instance.OpenDoor();
        
    }
}
