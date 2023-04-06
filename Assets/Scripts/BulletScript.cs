using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the bullet on impact if collide with a gameobject tagged "Enemy".
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // If the enemy has the EnemyBehaviour, then deal 1.0 point of damage to the collided enemy.
            if (collision.gameObject.GetComponent<EnemyBehaviour>())
            {
                collision.gameObject.GetComponent<EnemyBehaviour>().TakeHit(1);
            }
            Destroy(gameObject);
        }
    }
}
