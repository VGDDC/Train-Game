using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalPickup : MonoBehaviour //this allows us to pick up objects
{
    private static Inventory generalInventory; //player inventory (static because there's only one player)
    public GameObject itemButton;              //The slots in the inventory that the player can select to equip item

    // Start is called before the first frame update
    void Start()
    {
        generalInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //initialize inventory to point to the player's inventory
    }

    //Pickup an item and put it in the general inventory
    private void OnTriggerEnter2D(Collider2D pickup) { if (pickup.CompareTag("Player")) { //if a player collides with an object:
        for (int i = 0; i < generalInventory.slots.Length; i++) //loop through inventory slots
        {
            if (! generalInventory.isFull[i]) //if inventory slot isn't full
            {
                //Add item to inventory
                generalInventory.isFull[i] = true; //make slot full
                Instantiate(itemButton, generalInventory.slots[i].transform, false); //put item in inventory
                Destroy(gameObject); //destroy physical object as a physics entity
            }
        }
    } }

    //Use an item (only give the option to discard items when full)

    // Update is called once per frame
    void Update()
    {
        
    }
}
