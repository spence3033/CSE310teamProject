using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;

    public Inventory Inventory;
    public List<HotbarSlot> hotbarSlots = new List<HotbarSlot>(8);

    private void Start() {
        Inventory.OnInventoryChange += DrawInventory;
    }
    private void OnEnable() {
        Inventory.OnInventoryChange += DrawInventory;
    }
    private void OnDisable() {
        Inventory.OnInventoryChange -= DrawInventory;
    }


    // wipes the inventory clean for a new instance with possible updated values
    void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        hotbarSlots = new List<HotbarSlot>(8);
    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();

        Debug.Log(hotbarSlots.Capacity);
        for (int i = 0; i < inventory.Count; i++)
        {
            // create all 8 slots
            CreateInventorySlot();
            Debug.Log($"Created slot {i+1}");
        }

        Debug.Log(inventory.Count);
        for(int i = 0; i < inventory.Count; i++)
        {
            hotbarSlots[i].DrawSlot(inventory[i]);
            Debug.Log($"{inventory[i].itemData.displayName}");
        }
    }

    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        HotbarSlot newSlotComponent = newSlot.GetComponent<HotbarSlot>();
        newSlotComponent.ClearSlot();
        hotbarSlots.Add(newSlotComponent);
    }
}
