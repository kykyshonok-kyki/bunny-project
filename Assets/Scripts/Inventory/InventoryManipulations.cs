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

   public void pressedTakeButton()
    {

        var _item = lootedInventory.Container.Items[currentSlot].item;

        characterInventory.AddItem(_item, 1);
        lootedInventory.RemoveItem(currentSlot);

    }

    public void pressedRemoveButton()
    {

        var _item = lootedInventory.Container.Items[currentSlot].item;

        lootedInventory.AddItem(_item, 1);
        characterInventory.RemoveItem(currentSlot);

        displayedCharacterInventory.GetComponent<DisplayInventory>().UpdateDisplay();
        displayedLootedInventory.GetComponent<DisplayInventory>().UpdateDisplay();
    }
}
