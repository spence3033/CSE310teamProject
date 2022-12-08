using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Allows for use of custom events

// Inherits collect function from Collectible interface
public class Square: MonoBehaviour, Collectible
{
    // Establishes an event handler
    public delegate void HandleSquareCollected(ItemData itemData);
    public static event HandleSquareCollected OnSquareCollected;
    public ItemData squareData;
    public void Collect()
    {
        Debug.Log("Collected Square");
        Destroy(gameObject);
        OnSquareCollected?.Invoke(squareData);
    }

}
