//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor Object", menuName = "Items/Armors")]
public class ArmorObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Armor;
        isStackable = false;
    }

    public float protection;

}
