//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Data/Item", order = 51)]
public class Item : ScriptableObject
{
    public string nameItem;
    public int id;

    public float volumeItem;
    public float weightItem;
    
    public string descriptionItem;
    
}
