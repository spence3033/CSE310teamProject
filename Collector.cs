using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is to be referenced in the player controller class (as another script component)
Does a check on collision with another object to determine whether or not the item is a collectible.
If the item is a collectible, it will execute the item's Collection function.

Note: this, along with the collectible and the individual item's scripts are possibly interchangeable
with abstract classes and can be altered with polymorpism.
*/

public class Collector : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D collision) {
        Collectible collectible = collision.GetComponent<Collectible>();
        if(collectible != null)
        {
            collectible.Collect();
        }
    }
}
