using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public bool aimUp = false;
    public byte fireCoolDown = 0;
    public bool facesRight = true; //TODO make it so this inits to true or false depending on how we start the level
    
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(fireCoolDown != 0) { --fireCoolDown; } //update cooldown timer every frame
        
        ///////////////// MOVEMENTS /////////////////////////
        
        //Here, we read the user's inputs to move the player in the desired direction
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement)) { //when we're not moving
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity; //make us face the correct direction
            facesRight = movement > 0; //we're now facing right iff we're facing right
        } //the if statement is there to stop us from always facing left any time we stop
        
        //////////////// BUTTONS //////////////////////////
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) //if we press jump
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse); //make us jump upwards
        }
        
        if(Input.GetButtonDown("Aim Up")) { aimUp = true; } //enables upward aiming
        if(Input.GetButtonUp("Aim Up")) { aimUp = false; } //disables upward aiming TODO make sure this works

        if(Input.GetMouseButton(0) && fireCoolDown == 0) {
            if(aimUp) {
                //Instantiate(bullet, position above player, Quaternion.identity);
                //set bullet's velocity to be upwards
            }
            else if(facesRight) {
                //Instantiate(bullet, position right of player, Quaternion.identity);
                //set bullet's velocity to be rightwards
            }
            else {
                //Instantiate(bullet, position left of player, Quaternion.identity);
                //set bullet's velocity to be leftwards
            }
            //TODO actually instantiate the bullets & their velocities
            
            fireCoolDown = 40;
        }
    }

    //TODO Make a Dodge Function
    
    //TODO lowercase the variables (please)
    //example: movementSpeed instead of MovementSpeed
}
