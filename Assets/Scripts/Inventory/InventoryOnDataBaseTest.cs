//made by Nord

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryOnDataBaseTest : MonoBehaviour
{
    public List<Item> list;

    public GameObject cellPrefab;
    
    public float stockMaxWeight;
    public float maxWeight;
    private float currentWeight;


    public GameObject buttonAddAnItem;


    //Variable for the test only
    public Item theItem;

    void Start()
    {
        list = new List<Item>();
        Debug.Log("Inventory created");
    }
    //Checking the current amount of both empty and full slots in the inventory
    private int Checking()
    {
        int cellAmount = 0;
        cellAmount = list.Count;
        Debug.Log(cellAmount);
        return cellAmount;
    }

    //Adds an item into one's inventory
    public void AddItem(Item item)
    {
        float itemWeight = item.weightItem;
        if (currentWeight + itemWeight < maxWeight)
        {
            int maxIndex = Checking() - 1;

            list.Add(item);
            list[maxIndex + 1] = item;

            currentWeight += itemWeight;
            Debug.Log("currentWeight = " + currentWeight);

            GameObject newCell = Instantiate<GameObject>(cellPrefab);
            newCell.transform.SetParent(gameObject.transform.GetChild(0).transform.GetChild(0).transform);
            newCell.GetComponentInChildren<Text>().text = theItem.nameItem;
            newCell.transform.localScale = new Vector3(1, 1, 1);
        }
        
    }

    //Removes an item from one's inventory
    public void RemoveItem(GameObject invItem, Item item)
    {
        Destroy(invItem);
        list.Remove(item);
        currentWeight += -item.weightItem;
    }


    public void TakeAll(List<Item> anotherList)
    {
        
        int i = 0;
        do
        {
            AddItem(anotherList[i]);

            i++;
        } while (anotherList[i] != null);
    }


    //Testing the list
    public void AddAnItem()
    {
        AddItem(theItem);
    }

  










}
