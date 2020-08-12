//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Medicine;
        isStackable = true;
    }

    public float healthRestored;
}
