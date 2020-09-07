using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveButton : MonoBehaviour
{
    public void PressRemove()
    {
        gameObject.transform.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<InventoryManipulations>().PressedRemoveButton();
    }
}
