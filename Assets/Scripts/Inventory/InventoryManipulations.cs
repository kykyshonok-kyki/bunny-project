using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManipulations : MonoBehaviour
{

    public InventoryObject characterInventory;
    public InventoryObject lootedInventory;
    
    public GameObject displayedCharacterInventory;
    public GameObject displayedLootedInventory;

    public int currentSlot;


    public void CheckCurrentInventories()
    {
        characterInventory = displayedCharacterInventory.GetComponent<DisplayInventory>().inventory;
        lootedInventory = displayedLootedInventory.GetComponent<DisplayInventory>().inventory;
    }

    public void UpdateCurrentInventories()
    {
        displayedCharacterInventory.GetComponent<DisplayInventory>().inventory = characterInventory;
        displayedLootedInventory.GetComponent<DisplayInventory>().inventory = lootedInventory;
    }

 /*   public void pressedTakeButton(int _i)
    {


        var _item = lootedInventory.Container.Items[_i].item;

        characterInventory.AddItem(_item, 1);
        lootedInventory.RemoveItem(_i);

    }

    public void pressedRemoveButton(GameObject invCell)
    {

        var _item = lootedInventory.Container.Items[_i].item;

        characterInventory.RemoveItem(_i);
        lootedInventory.AddItem(_item, 1);
    }*/
}
