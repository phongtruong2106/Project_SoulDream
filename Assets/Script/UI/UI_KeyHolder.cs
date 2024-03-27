using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : UI
{
    [SerializeField] protected PlayerControler playerControler;
    protected override void Start()
    {
        base.Start();
        playerControler._inventory.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    protected virtual void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    
    protected override void UpdateVisual()
    {
        foreach(Transform child in container)
        {
            if(child == Template) continue;
            Destroy(child.gameObject);
        }
        // //
        // List<Key.KeyType> keyList = keyHolder.GetKeyList();
        // for(int i = 0; i < keyList.Count; i++)
        // {
        //     Key.KeyType keyType = keyList[i];
        //     Transform keyTransform = Instantiate(Template, container);
        //     keyTransform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(50 * i, 0, 0);
        //     Image keyImage = keyTransform.Find("Key").GetComponent<Image>();
        //     switch (keyType)
        //     {
        //         default:
        //             case Key.KeyType.door:keyImage.color = Color.black; break;
        //             case Key.KeyType.able:keyImage.color = Color.grey; break;
        //             case Key.KeyType.box:keyImage.color = Color.yellow; break;
        //     }
        // }
    }
}
