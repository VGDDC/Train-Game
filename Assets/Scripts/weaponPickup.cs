using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour //This allows us to pickup weapons into the weapon slot
{
    private static Inventory weaponInventory; //player weapon inventory (static because there's only one player)
    public GameObject itemButton;             //The weapon sprite that appears in the weapon inventory.

    // Start is called before the first frame update
    void Start()
    {
        weaponInventory = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Inventory>();
        //initialize inventory to point to the player's inventory
    }

    //Pickup up a weapon and add it to your inventory when you collide with it.
    private void OnTriggerEnter2D(Collider2D pickup)
    {
        if (pickup.CompareTag("Weapon")) //if a player collides with an weapon:
        {
            for(int i=0; i<weaponInventory.slots.Length; i++)  //loop through weapon inventory slots
            {
                if(weaponInventory.isFull[i] == false) //if weapon inventory slot isn't full
                {
                    //Add weapon to weapon inventory
                    weaponInventory.isFull[i] = true; //make slot full
                    Instantiate(itemButton, weaponInventory.slots[i].transform, false);  //put weapon in weapon inventory
                    Destroy(gameObject); //destroy physical object as a physics entity
                }
            }
        }
    }

    //Equip a weapon to the weapon inventory (only give the option to discard the item when the weapon inventory is full).


    // Update is called once per frame
    void Update()
    {
        
    }
}
