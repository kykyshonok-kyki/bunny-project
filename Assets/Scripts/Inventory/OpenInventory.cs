using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject mainUI;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void InventorySwitch()
    {
        if (gameObject.activeSelf)
        {
            mainUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            mainUI.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
