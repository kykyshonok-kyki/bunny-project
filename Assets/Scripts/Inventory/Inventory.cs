//made by Nord
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryButton;
    public GameObject mainUI;

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
            mainUI.SetActive(true);
            
        }
        else
        {
            
            gameObject.SetActive(true);
            mainUI.SetActive(false);
            
        }
    }
    
}
