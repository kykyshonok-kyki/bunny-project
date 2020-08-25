using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManipulations : MonoBehaviour
{

    public InventoryObject characterInventory;
    public InventoryObject lootedInventory;
    
    public GameObject displayedCharacterInventory;
    public GameObject displayedLootedInventory;



    public void checkCurrentInventories()
    {
        characterInventory = displayedCharacterInventory.GetComponent<DisplayInventory>().inventory;
        lootedInventory = displayedLootedInventory.GetComponent<DisplayInventory>().inventory;
    }

    public void pressedTakeButton(int _i)
    {
        var _item = lootedInventory.Container.Items[_i].item;

        characterInventory.AddItem(_item, 1);
        lootedInventory.RemoveItem(_i);

    }

    public void pressedRemoveButton(int _i)
    {
        var _item = lootedInventory.Container.Items[_i].item;

        characterInventory.RemoveItem(_i);
        lootedInventory.AddItem(_item, 1);
    }
}
