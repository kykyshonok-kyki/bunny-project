//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject draggedItem;
    InventoryCharacter inventory;
    
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("").GetComponent<InventoryCharacter>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedItem = gameObject;
        inventory.dragPrefab.SetActive(true);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        inventory.dragPrefab.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggedItem = null;
        inventory.dragPrefab.SetActive(false);
    }


}
