using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : NewMonoBehaviour
{
    [SerializeField] protected KeyHolder keyHolder;
    private Transform container;
    private Transform keyTemplate;

    protected override void Awake()
    {
        base.Awake();
        container = transform.Find("container");
        keyTemplate = container.Find("keyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }

    protected override void Start()
    {
        base.Start();
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    protected virtual void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    protected virtual void UpdateVisual()
    {
        //clear up old key
        foreach(Transform child in container)
        {
            if(child == keyTemplate) continue;
            Destroy(child.gameObject);
        }
        //
        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for(int i = 0; i < keyList.Count; i++)
        {
            Key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTransform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(50 * i, 0, 0);
            Image keyImage = keyTransform.Find("Key").GetComponent<Image>();
            switch (keyType)
            {
                default:
                    case Key.KeyType.door:keyImage.color = Color.black; break;
                    case Key.KeyType.able:keyImage.color = Color.grey; break;
                    case Key.KeyType.box:keyImage.color = Color.yellow; break;
            }
        }
    }
}
