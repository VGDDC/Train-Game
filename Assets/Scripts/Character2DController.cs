using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Here, we read the user's inputs to move the player in the desired direction
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement)) { //when we're not moving
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity; //make us face the correct direction
        } //the if statement is there to stop us from always facing left any time we stop

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) //if we press jump
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse); //make us jump upwards
        }
    }

    //TODO Make a Dodge Function
}
