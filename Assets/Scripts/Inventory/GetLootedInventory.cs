//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLootedInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject lootedInventory;
    public List<GameObject> lootedObjects = new List<GameObject>();
    public List<InventoryObject> lootedInventories = new List<InventoryObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Container")
        {
            lootedObjects.Add(collision.gameObject);
            LootedInventoryManipulations();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Container")
        {
            lootedObjects.Remove(collision.gameObject);
            LootedInventoryManipulations();

            
        }
    }

    public void Start()
    {
        lootedInventory.GetComponent<DisplayInventory>().inventoriesDisplayed.Clear();
    }

    private void LootedInventoryManipulations()
    {
        lootedInventory.GetComponent<DisplayInventory>().inventoriesDisplayed.Clear();
        foreach (GameObject @object in lootedObjects)
        {
            //lootedInventories.Add(@object.GetComponent<Container>().inventory);

            lootedInventory.GetComponent<DisplayInventory>().inventoriesDisplayed.Add(@object.GetComponent<Container>().inventory);
        }

    }
}