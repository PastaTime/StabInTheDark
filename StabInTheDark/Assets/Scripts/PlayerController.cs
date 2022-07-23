using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    public float speed = 100f; // Speed variable
    public Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement; // Set the variable 'movement' as a Vector3 (x,y,z)
    
 
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
 

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical")).normalized;
    }
 
 
    void FixedUpdate()
    {
        moveCharacter(movement); // We call the function 'moveCharacter' in FixedUpdate for Physics movement
    }
 
 
 
    void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
 
}