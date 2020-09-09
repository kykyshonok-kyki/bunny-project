//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInvCell : MonoBehaviour
{
    public int inventoryAssigned;
    public int numberInList;
    public GameObject theInventoryUI;
    public GameObject theInventoryPanel;
    public GameObject theLootedPanel;

    public void Start()
    {
        theInventoryUI = gameObject.transform.parent.parent.parent.parent.gameObject;
        theInventoryPanel = theInventoryUI.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        theLootedPanel = theInventoryUI.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnBeingPressed()
    {
        if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            OffAll();
        }
        else
        {
            OffAll();


            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            theInventoryUI.GetComponent<InventoryManipulations>().currentSlot = numberInList;
            theInventoryUI.GetComponent<InventoryManipulations>().currentInventory = inventoryAssigned;
        }
    }

    private void OffAll()
    {

        int inventoriesCount = theInventoryPanel.GetComponent<DisplayInventory>().inventoriesDisplayed.Count;
        for (int j = 0; j < inventoriesCount; j++)
        {
            int maxIndex = theInventoryPanel.GetComponent<DisplayInventory>().inventoriesDisplayed[j].Container.Items.Count;
            for (int i = 0; i < maxIndex; i++)
            {
                theInventoryPanel.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
            }
        }


        int _inventoriesCount = theLootedPanel.GetComponent<DisplayInventory>().inventoriesDisplayed.Count;
        for (int k = 0; k < _inventoriesCount; k++) 
        { 
            int _maxIndex = theLootedPanel.GetComponent<DisplayInventory>().inventoriesDisplayed[k].Container.Items.Count;
            for (int i = 0; i < _maxIndex; i++)
            {
                theLootedPanel.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
            } 
        }

    }




}
