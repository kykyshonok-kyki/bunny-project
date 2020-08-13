//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;
using System.ComponentModel;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class InventoryObject : ScriptableObject
{
    public float stockCapacity;
    public float maxCapacity;
    public float currentCapacity;
    public ItemDataBaseObject database;
    public string savePath;
    public Inventory Container;



    public void AddItem(Item _item, int _amount)
    {
        if (currentCapacity + _item.volume <= maxCapacity)
        {
            bool hasItem = false;
            if (_item.isStackable)
            {
                for (int i = 0; i < Container.Items.Count; i++)
                {
                    if (Container.Items[i].item.id == _item.id)
                    {
                        Container.Items[i].AddAmount(_amount);
                        hasItem = true;
                        break;
                    }
                }
            }
            if (!hasItem)
            {
                Container.Items.Add(new InventorySlot(_item.id, _item, _amount));
            }
            currentCapacity += _item.volume;
        }
    }




    public void RemoveItem()
    {

    }


    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //    BinaryFormatter bf = new BinaryFormatter();
            //    FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //    JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //    file.Close();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Container = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }


    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
    }
}



[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();
}


[System.Serializable]
public class InventorySlot
{
    public int id;
    public Item item;
    public int amount;
    public InventorySlot(int _id, Item _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}