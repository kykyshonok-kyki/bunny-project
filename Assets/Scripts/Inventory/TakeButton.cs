using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeButton : MonoBehaviour
{
    public void PressTake()
    {
        gameObject.transform.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<InventoryManipulations>().PressedTakeButton();
    }
}
