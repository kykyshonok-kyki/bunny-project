//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Data/Items/Weapons", order = 52)]
public class Weapons : Item
{
    //Immanent components
    public int magazineSize;
    public float damage;
    public float fireRate;
    public AmmoType ammoType;
    public WeaponType weaponType;
    public WeaponSize weaponSize;

    //Changing components
    //public int currentMagazineSize;
}

public enum AmmoType { }
public enum WeaponType { }
public enum WeaponSize {small, medium }
