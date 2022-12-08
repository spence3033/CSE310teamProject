using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;
    public TextMeshProUGUI labelText;

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if (item== null)
        {
            ClearSlot();
            Debug.Log("Tried drawing nothing");
            return;
        }

        icon.enabled = true;
        stackSizeText.enabled = true;
        labelText.enabled = true;

        icon.sprite = item.itemData.icon;
        labelText.text = item.itemData.displayName;
        stackSizeText.text = item.stackSize.ToString();
    }
}
