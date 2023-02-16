using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScript : MonoBehaviour
{

    public float crouchHeight;

    private Vector2 normalHeight;
    private float yInput;


    private void Start()
    {
        normalHeight = transform.localScale;
    }

    private void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");

        if (yInput < 0)
        {
            if (transform.localScale.y != crouchHeight)
                transform.localScale = new Vector2(normalHeight.x, crouchHeight);
        }
        else
        {
            if (transform.localScale.y != normalHeight.y)
                transform.localScale = normalHeight;
        }
        }
}