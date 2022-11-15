using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rbody;
    Vector2 leftMoveVector;
    Vector2 rightMoveVector;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (true) {
            rbody.AddForce(rightMoveVector);
        }
        else if (true) {
            rbody.AddForce(leftMoveVector);
        }
        
    }

    void Dodge() {

    }

    void Jump() {

    }
}
