//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public List<InventoryObject> inventoriesDisplayed = new List<InventoryObject>();
    //public InventoryObject inventory;
    public GameObject cellPrefab;

    private List<GameObject> cellList = new List<GameObject>();


    public void OnEnable()
    {
        DeleteDisplay();
        CreateDisplay();
    }

    public void OnApplicationQuit()
    {
        DeleteDisplay();
    }

    public void UpdateDisplay()
    {

        DeleteDisplay();

        CreateDisplay();

    }

    public void DeleteDisplay()
    {
        foreach (GameObject cell in cellList)
        {
            Destroy(cell);
        }
        cellList.Clear();
    }


    public void CreateDisplay()
    {
        int numberOfInventories = inventoriesDisplayed.Count;
        for (int j = 0; j < numberOfInventories; j++)
        {
            var maxIndex = inventoriesDisplayed[j].Container.Items.Count;
            for (int i = 0; i < maxIndex; i++)
            {
                var obj = Instantiate(cellPrefab, gameObject.transform);
                obj.GetComponent<TestInvCell>().numberInList = i;
                obj.GetComponent<TestInvCell>().inventoryAssigned = j;
                cellList.Add(obj);
                obj.GetComponentInChildren<Text>().text = inventoriesDisplayed[j].Container.Items[i].item.name;

            }
        }
    }
}
