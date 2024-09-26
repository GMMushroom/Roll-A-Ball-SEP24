using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Gets the RigidBody component attached to this gameObject
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store the Horizontal value in a float
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the Vertical value in a float
        float moveVertical = Input.GetAxis("Vertical");
        
        //Create a new Vector3 based on the Horizontal and Vertical values
        Vector3 movement = new Vector3(moveHorizontal, 0 , moveVertical);
        rb.AddForce(movement * speed * Time.deltaTime);
    }
}
