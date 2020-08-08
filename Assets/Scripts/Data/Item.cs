//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : ScriptableObject
{
    public string nameItem;
    public int id;
    public bool isStackable;

    public Sprite image;

    public float weightItem;
    [Multiline()]
    public string descriptionItem;
    public string pathIcon;
    public string pathPrefab;

    //public int countItem;
}
