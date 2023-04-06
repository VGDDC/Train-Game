using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float Hitpoints;
    public float MaxHitpoints = 5;
    //public HealthbarBehaviour Healthbar;

    void Start()
    {
        Hitpoints = MaxHitpoints; //initialize health
        //Healthbar.SetHealth(Hitpoints, MaxHitpoints); //update health bar
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage; //decrement health
        //Healthbar.SetHealth(Hitpoints, MaxHitpoints); //update health bar

        if (Hitpoints <= 0) //if it dies, make it die
        {
            Destroy(gameObject);
        }
    }
}
