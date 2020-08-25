//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    //public MouseItem mouseItem;

    public InventoryObject inventory;
    public GameObject inventoryPrefab;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    //Метод, генерирующий отображения инвентаря
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform );
            
            obj.GetComponentInChildren<Text>().text = inventory.Container.Items[i].item.name;

            itemsDisplayed.Add(inventory.Container.Items[i], obj);
        }
    }

    //Метод, проверяющий "актуальность" отображаемого
    //Надо будет как-нибудь переделать не через апдейт
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container.Items[i]))
            {
                itemsDisplayed[inventory.Container.Items[i]].GetComponentInChildren<Text>().text = inventory.Container.Items[i].item.name;
            }
            else
            {
                var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponentInChildren<Text>().text = inventory.Container.Items[i].item.name;

                itemsDisplayed.Add(inventory.Container.Items[i], obj);
            }
        }
    }


    //Hui znaet
    /*
    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }


    public void OnEnter(GameObject obj)
    {
        
    }
    public void OnExit(GameObject obj)
    {

    }
    public void OnDragStart(GameObject obj)
    {
        
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50, 50);
        mouseObject.transform.SetParent(transform.parent);
        var img = mouseObject.AddComponent<Image>();

        img.raycastTarget = false;


    }
    public void OnDragEnd(GameObject obj)
    {

    }
    public void OnDrag(GameObject obj)
    {

    }
    */
}

/*
public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
}
*/