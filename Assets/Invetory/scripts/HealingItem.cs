using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Object", menuName = "Invetory System/Items/Healing")]
public class HealingItem : itemObject
{
    public int healtRestore;
    public void Awake()
    {
        type = ItemType.Healing;
    }
}
