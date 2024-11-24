using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControls : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(moveHorizontal * speed, 0, moveVertical * speed);
        Quaternion deltaRotation = Quaternion.Euler(moveVector * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
