using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
    private Inventory weaponInventory;
    private Inventory generalInventory;

    // Start is called before the first frame update
    void Start()
    {
        weaponInventory = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Inventory>();
        generalInventory = GameObject.FindGameObjectWithTag("Items").GetComponent<Inventory>();
    }

    //Pickup up a weapon and add it to your inventory when you collide with it.
    private void OnTriggerEnter2D(Collider2D pickup)
    {
        if (pickup.CompareTag("Weapon"))
        {
            for(int i=0; i<weaponInventory.slots.Length; i++)
            {
                if(weaponInventory.isFull[i] == false)
                {
                    //Add weapon to weapon inventory
                    weaponInventory.isFull[i] = true;
                    Destroy(gameObject);
                }
            }
        }
        if(pickup.CompareTag("Inventory"))
        {
            for(int i=0; i<generalInventory.slots.Length; i++)
            {
                if
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
