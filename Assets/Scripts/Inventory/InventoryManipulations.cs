//made by Kurochitskiy nicholasnordwind@gmail.com
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

        displayedCharacterInventory.GetComponent<DisplayInventory>().UpdateDisplay();
        displayedLootedInventory.GetComponent<DisplayInventory>().UpdateDisplay();
    }

   public void pressedTakeButton()
    {
        Debug.Log("TakeButton");
        CheckCurrentInventories();
        var _item = lootedInventory.Container.Items[currentSlot].item;

        characterInventory.AddItem(_item, 1);
        lootedInventory.RemoveItem(currentSlot);

        UpdateCurrentInventories();
        Debug.Log("TakeButton");
    }

    public void pressedRemoveButton()
    {
        Debug.Log("RemoveButton");
        CheckCurrentInventories();
        Debug.Log(currentSlot);
        var _item = characterInventory.Container.Items[currentSlot].item;
        Debug.Log("RemoveButton2");
        lootedInventory.AddItem(_item, 1);
        characterInventory.RemoveItem(currentSlot);

        UpdateCurrentInventories();
        Debug.Log("RemoveButton2");
    }
}
