//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    public int id;
    public string nameItem;
    [TextArea(15,20)]
    public string descriptionItem;
    public ItemType type;
    public float weightItem;
    public float volumeItem;
    public float value;
    public bool isStackable;
    //public GameObject prefab;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Medicine,
    Resourses
}



[System.Serializable]
public class Item
{
    public string name;
    public int id;
    public float volume;
    public bool isStackable;
    public Item(ItemObject item)
    {
        name = item.nameItem;
        id = item.id;
        volume = item.volumeItem;
        isStackable = item.isStackable;
    }
}