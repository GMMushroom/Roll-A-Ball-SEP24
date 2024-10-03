using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;
    private int pickupCount;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the RigidBody component attached to this gameObject
        rb = GetComponent<Rigidbody>();
        //Get the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //Run the CheckPickups() function
        CheckPickups();
        //Gets the timer Object
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            //Destroy collided object
            Destroy(other.gameObject);
            //Decrement pickupCount
            pickupCount--;
            //Run CheckPickups() function again
            CheckPickups();
        }
    }

    private void CheckPickups()
    {
        print("Pickups left: " + pickupCount);

        if (pickupCount == 0)
        {
            timer.StopTimer();
            WinGame();
        }
    }

    private void WinGame()
    {
        print("CONGRATULATIONS!!! Your time was: " + timer.GetTime().ToString("F2"));
    }
}
