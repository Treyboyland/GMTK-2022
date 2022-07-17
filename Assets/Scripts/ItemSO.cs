using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Game/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    string itemName;

    public string ItemName { get { return itemName; } }
}
