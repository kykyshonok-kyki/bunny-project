//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Items/Weapons")]
public class WeaponObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Weapon;
        isStackable = false;
    }

    public float damage;
    public AmmoType ammoType;
    public int magazineSize;
}

public enum AmmoType
{

}
