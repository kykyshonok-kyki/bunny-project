//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManipulations : MonoBehaviour
{
    public List<InventoryObject> lootedInventories = new List<InventoryObject>();

    public InventoryObject characterInventory;
    //public InventoryObject lootedInventory;
    
    public GameObject displayedCharacterInventory;
    public GameObject displayedLootedInventory;

    public int currentSlot;
    public int currentInventory;

    
    public void CheckCurrentInventories()
    {
        characterInventory = displayedCharacterInventory.GetComponent<DisplayInventory>().inventoriesDisplayed[0];
        lootedInventories = displayedLootedInventory.GetComponent<DisplayInventory>().inventoriesDisplayed;
    }

    public void UpdateCurrentInventories()
    {
        displayedCharacterInventory.GetComponent<DisplayInventory>().inventoriesDisplayed[0] = characterInventory;
        displayedLootedInventory.GetComponent<DisplayInventory>().inventoriesDisplayed = lootedInventories;

        displayedCharacterInventory.GetComponent<DisplayInventory>().UpdateDisplay();
        displayedLootedInventory.GetComponent<DisplayInventory>().UpdateDisplay();
    }

   public void PressedTakeButton()
    {
        
        CheckCurrentInventories();
        var _item = lootedInventories[currentInventory].Container.Items[currentSlot].item;

        characterInventory.AddItem(_item, 1);
        lootedInventories[currentInventory].RemoveItem(currentSlot);

        UpdateCurrentInventories();

    }

    public void PressedRemoveButton()
    {
        
        CheckCurrentInventories();

        var _item = characterInventory.Container.Items[currentSlot].item;
        
        lootedInventories[0].AddItem(_item, 1);
        characterInventory.RemoveItem(currentSlot);

        UpdateCurrentInventories();
        
    }
}
