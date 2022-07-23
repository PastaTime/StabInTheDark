using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticTestPlayer : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    void Update()
    {    
        float inX = Input.GetAxis("Horizontal");
        float inY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveSpeed*inX,0.0f,moveSpeed*inY);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

}