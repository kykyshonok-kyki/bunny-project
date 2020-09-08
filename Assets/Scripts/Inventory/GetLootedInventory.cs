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
        lootedInventory.GetComponent<DisplayInventory>().inventory.Container.Items.Clear();
    }

    private void LootedInventoryManipulations()
    {
        lootedInventory.GetComponent<DisplayInventory>().inventory.Container.Items.Clear();
        foreach (GameObject @object in lootedObjects)
        {
            foreach (var itemSlot in @object.GetComponent<Container>().inventory.Container.Items)
            {
                lootedInventory.GetComponent<DisplayInventory>().inventory.Container.Items.Add(new InventorySlot(itemSlot.item, itemSlot.amount));
            }
        }

    }
}