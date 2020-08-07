//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewArmorData", menuName = "Data/Items/Armors", order = 52)]
public class Armor : Item
{
    //Immanent components
    public int armor;
    public int durability;
    public int capacity;

    //Changing components
    //public float currentDurability;
}
