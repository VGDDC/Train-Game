using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalPickup : MonoBehaviour
{
    private Inventory generalInventory;
    public GameObject itemButton;

    // Start is called before the first frame update
    void Start()
    {
        generalInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D pickup)
    {
        if (pickup.CompareTag("Player"))
        {
            for (int i = 0; i < generalInventory.slots.Length; i++)
            {
                if (generalInventory.isFull[i] == false)
                {
                    //Add item to inventory
                    generalInventory.isFull[i] = true;
                    Instantiate(itemButton, generalInventory.slots[i].transform, false);
                    Destroy(gameObject);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
