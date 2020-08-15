//made by Nord
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryButton;
    public GameObject mainUI;
    void Start()
    {
        gameObject.SetActive(false);
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
