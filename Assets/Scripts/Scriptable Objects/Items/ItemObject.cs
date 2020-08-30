//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    public int id;
    public new string name;
    [TextArea(15,20)]
    public string description;
    public ItemType type;
    public float weight;
    public float volume;
    public float costValue;
    public bool isStackable;

    /*public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }*/
}

public enum ItemType
{
    Weapon,
    Armor,
    Medicine,
    Resourses
}


//Я всё ещё не смог осознать, зачем я в класс ItemObject зарядил класс Item
/*
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
}*/