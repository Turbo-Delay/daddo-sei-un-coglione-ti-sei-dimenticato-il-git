using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Object", menuName = "Invetory System/Items/Gun")]
public class GunObject : itemObject
{
    public float damage;
    public float magazieSize;
    private void Awake()
    {
        type = ItemType.Gun;
    }
}
