//made by Nord
using UnityEngine;
using UnityEditor;

public class CreateInvCell : ScriptableObject
{
    public Item itemInCell;

    //конструктор для создания пустого слота
    public void InventorySlot()
    {

    }
    //конструктор для создания слота с предметом
    public void InventorySlot(Item item)
    {
        itemInCell = item;
    }
}