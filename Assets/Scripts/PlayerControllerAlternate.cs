using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerControllerAlternate : MonoBehaviour
{
    public float speed = 100f; // Speed variable
    public float turnSpeed = 1.0f; // Turn speed variable
    public Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement; // Set the variable 'movement' as a Vector3 (x,y,z)
    public bool alwaysFaceNorth = true;

    float rotateInput = 0.0f;
    Vector3 autoRotation;
 
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
 

    void Update()
    {
        rotateInput = Input.GetAxis("RotateX");
        // Debug.Log(rotateInput);
        movement = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
    }
 
 
    void FixedUpdate()
    {
        moveCharacter(movement); // We call the function 'moveCharacter' in FixedUpdate for Physics movement
    }
 
 
    void moveCharacter(Vector3 direction)
    {
        if (alwaysFaceNorth)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
            //rb.velocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
            transform.Rotate(Vector3.up * rotateInput * turnSpeed * Time.fixedDeltaTime);
        }
    }
 
}