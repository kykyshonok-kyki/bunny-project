//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCharacter : MonoBehaviour
{
    public GameObject takeAllButton;
    public GameObject dragPrefab;
    public Transform inventoryContent;

    List<Item> list;

    private int capacity;
    private int currentCapacity;

    void Start()
    {
        list = new List<Item>();
    }

    public void TakeAll()
    {
        
    }
    


}
