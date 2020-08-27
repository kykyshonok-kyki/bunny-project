using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInvCell : MonoBehaviour
{
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
        }
    }

    private void OffAll()
    {
        int maxIndex = theInventoryPanel.GetComponent<DisplayInventory>().inventory.Container.Items.Count;
        for (int i = 0; i < maxIndex; i++)
        {
            theInventoryPanel.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }

        int _maxIndex = theLootedPanel.GetComponent<DisplayInventory>().inventory.Container.Items.Count;
        for (int i = 0; i < _maxIndex; i++)
        {
            theLootedPanel.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
    }


    /*private void Switch()
    {
        if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }*/

}
