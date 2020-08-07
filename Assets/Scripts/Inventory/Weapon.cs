//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int currentMagazineSize;
}

public enum AmmoType { }
public enum WeaponType { }
public enum WeaponSize { }
