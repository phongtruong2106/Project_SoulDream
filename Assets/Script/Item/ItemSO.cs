using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptAbleObject/ItemProfile")]
public class ItemSO : ScriptableObject
{
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no-name";
}