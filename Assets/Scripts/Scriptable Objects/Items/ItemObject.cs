//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    public string nameItem;
    [TextArea(15,20)]
    public string descriptionItem;
    public ItemType type;
    public float weightItem;
    public float volumeItem;
    public float value;
    public bool isStackable;
    public GameObject prefab;
}

public enum ItemType
{
    Weapon,
    Armor,
    Medicine,
    Resourses
}