using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
}

[System.Serializable]

public class ItemItem
{
    public int id;
    public string name;
    public Sprite image;
}
