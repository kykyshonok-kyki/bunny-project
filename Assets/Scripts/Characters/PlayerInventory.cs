//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;





    public void ClearInventory()
    {
        inventory.Container.Items.Clear();
    }
}
