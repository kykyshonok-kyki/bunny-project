//made by Kurochitskiy nicholasnordwind@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public float stockCapacity;
    public float maxCapacity;
    public float currentCapacity;
    private ItemDataBaseObject database;
    public string savePath;

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDataBaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resourses/DataBase/Database.asset", typeof(ItemDataBaseObject));
#else
        database = Resources.Load<ItemDataBaseObject>("DataBase/Database.asset");
#endif
    }

    public void AddItem(ItemObject _item, int _amount)
    {
        if (currentCapacity + _item.volumeItem <= maxCapacity)
        {
            bool hasItem = false;
            if (_item.isStackable)
            {
                for (int i = 0; i < Container.Count; i++)
                {
                    if (Container[i].item == _item)
                    {
                        Container[i].AddAmount(_amount);
                        hasItem = true;
                        break;
                    }
                }
            }
            if (!hasItem)
            {
                Container.Add(new InventorySlot(database.GetId[_item], _item, _amount));
            }
            currentCapacity += _item.volumeItem;
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].item = database.GetItem[Container[i].id];
        }
    }

    public void OnBeforeSerialize()
    {
    }

    public void RemoveItem()
    {

    }


    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }
}



[System.Serializable]
public class InventorySlot
{
    public int id;
    public ItemObject item;
    public int amount;
    public InventorySlot(int _id, ItemObject _item, int _amount)
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