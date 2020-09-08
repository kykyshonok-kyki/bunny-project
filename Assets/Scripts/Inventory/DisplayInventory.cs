//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
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

    public void CreateDisplay()
    {
        var maxIndex = inventory.Container.Items.Count;
        for (int i = 0; i < maxIndex; i++)
        {
            var obj = Instantiate(cellPrefab, gameObject.transform);
            obj.GetComponent<TestInvCell>().numberInList = i;
            cellList.Add(obj);
            obj.GetComponentInChildren<Text>().text = inventory.Container.Items[i].item.name;

        }
    }

    public void DeleteDisplay()
    {
        foreach (GameObject cell in cellList)
        {
            Destroy(cell);
        }
        cellList.Clear();
    }


}
