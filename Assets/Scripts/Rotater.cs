using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 rotationValue = new Vector3(15, 30, 45);

    void Update()
    {
        //Rotate the object over time
        transform.Rotate(rotationValue * Time.deltaTime * speed);
    }
}
