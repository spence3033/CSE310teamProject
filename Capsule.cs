using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Allows for use of custom events

// Inherits collect function from Collectible interface
public class Capsule : MonoBehaviour, Collectible
{
    // Establishes an event handler
    public delegate void HandleCapsuleCollected(ItemData itemData);
    public static event HandleCapsuleCollected OnCapsuleCollected;
    public ItemData capsuleData;
    public void Collect()
    {
        Debug.Log("Collected Capsule");
        Destroy(gameObject);
        OnCapsuleCollected?.Invoke(capsuleData);
    }

}
