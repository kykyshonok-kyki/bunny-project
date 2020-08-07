//made by Nord
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryButton;

    List<Item> item;

    void Start()
    {
        gameObject.SetActive(false);
        item = new List<Item>();


    }



    public void SwitchInv()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    
}
