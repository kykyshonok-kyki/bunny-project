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
    private float currentCapacity;
    public ItemDataBaseObject database;
    public string savePath;
    public Inventory Container;


    private void checkCurrentCapacity()
    {
        currentCapacity = 0;
        for (int i = 0; i < Container.Items.Count; i++)
        {
            currentCapacity += Container.Items[i].item.volume;
        }
    }

    //Метод добавления предмета в инвентарь
    public void AddItem(ItemObject _item, int _amount)
    {
        if (currentCapacity + _item.volume <= maxCapacity)
        {
            bool hasItem = false;
            if (_item.isStackable)
            {
                for (int i = 0; i < Container.Items.Count; i++)
                {
                    if (Container.Items[i].id == _item.id)
                    {
                        Container.Items[i].AddAmount(_amount);
                        hasItem = true;
                        break;
                    }
                }
            }
            if (!hasItem)
            {
                Container.Items.Add(new InventorySlot(_item, _amount));
            }
            currentCapacity += _item.volume;
        }
    }



    //Метод удаления предмета из инвентаря, в качестве параметра в функцию передаётся номер предмета в List
    public void RemoveItem(int _i)
    {
        if (Container.Items[_i].amount > 1)
        {
            Container.Items[_i].RemoveAmount(1);
        }
        else
        {
            Container.Items.Remove(Container.Items[_i]);
        }
    }


    //Здесь будет метод генерирования "случайных" объектов в инвентаре при старте уровня... Наверное


    //Раздел, отвечающий за сохранение, загрузку и удаление инвентаря
    [ContextMenu("Save")]
    public void Save()
    {


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
    //Конец раздела
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
    public ItemObject item;
    public int amount;
    public InventorySlot(/*int _id,*/ ItemObject _item, int _amount)
    {
        //id = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }
}