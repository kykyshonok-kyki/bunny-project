//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;

public class InventoryCharacter : MonoBehaviour
{
    public DataBase data;

    public GameObject takeAllButton;
    public GameObject dragPrefab;
    public Transform inventoryContent;

    List<ItemInventory> list = new List<ItemInventory>();

    private int capacity;
    private int currentCapacity;

    public int maxCount;

    public GameObject gameObjShow;

    public GameObject InventoryMainObject;


    public Camera cam;
    public EventSystem es;

    public int currentID;
    public ItemInventory currentItem;

    public RectTransform movingObject;
    public Vector3 offset;

    public void AddItem(int id, Item item, int count)
    {
        list[id].id = item.id;
        list[id].count = count;
        list[id].itemGameObj.GetComponent<Image>().sprite = item.image;

        if (count > 1 && item.id != 0)
        {
            list[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        }
        else
        {
            list[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddInventoryItem(int id, ItemInventory invItem)
    {
        list[id].id = invItem.id;
        list[id].count = invItem.count;
        list[id].itemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].image;

        if (invItem.count > 1 && invItem.id != 0)
        {
            list[id].itemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            list[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddGraphics()
    {
        for (int i = 0; i<maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });


            list.Add(ii);
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (list[i].id != -1 && list[i].count > 1)
            {
                list[i].itemGameObj.GetComponentInChildren<Text>().text = list[i].count.ToString();
            }
            else
            {
                list[i].itemGameObj.GetComponentInChildren<Text>().text = "";
            }

            list[i].itemGameObj.GetComponent<Image>().sprite = data.items[list[i].id].image;
        }
    }

    public void SelectObject()
    {
        if (currentID == -1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(list[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = currentItem.image;

            AddItem(currentID, data.items[0], 0);
        }
        else
        {
            AddInventoryItem(currentID, list[int.Parse(es.currentSelectedGameObject.name)]);

            AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
            currentID = -1;

            movingObject.gameObject.SetActive(false);
        }
    }
    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();

        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;

        return New;
    }
    void Start()
    {
        //list = new List<Item>();
    }

    public void TakeAll()
    {
        
    }
    


}

[System.Serializable]

public class ItemInventory
{
    public int id;
    public GameObject itemGameObj;

    public int count;
    public Sprite image;
}
