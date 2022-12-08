using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{ 
    public static event Action<List<InventoryItem>> OnInventoryChange;
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    void Start() {
        OnInventoryChange?.Invoke(inventory);
    }
    public void OnEnable() {
        Capsule.OnCapsuleCollected += Add;
        Square.OnSquareCollected += Add;
    }

    public void OnDisable() {
        Capsule.OnCapsuleCollected -= Add;
        Square.OnSquareCollected -= Add;
    }
    public void Add(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");

            OnInventoryChange?.Invoke(inventory);
            Debug.Log("Inventory update successful");
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"{itemData.displayName} has been added to the inventory");

            OnInventoryChange?.Invoke(inventory);
            Debug.Log("Updated inventory");
        }
    }
    public void Remove(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();

            // conditional check if the inventory has no more instances of the item
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
            // OnInventoryChange?.Invoke(inventory);
        }
    }
}