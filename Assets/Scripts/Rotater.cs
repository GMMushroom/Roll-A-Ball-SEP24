using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateType { Fixed, Continuous }

public class Rotater : MonoBehaviour
{
    public float waitTime = 0;
    public float speed = 1.0f;
    bool rotated = false;
    private Vector3 startRotation;
    public Vector3 toRotation = new Vector3(15, 30, 45);
    public RotateType rotateType;

    private void Start()
    {
        startRotation = transform.eulerAngles;
        StartCoroutine(Rotate());
    }

    public void ToggleWorldTilt(bool _tilt)
    {
        if (_tilt)
            rotateType = RotateType.Fixed;
        else
            rotateType = RotateType.Continuous;
    }

    void Update()
    {
        if (rotateType == RotateType.Continuous)
        {
            //Rotate the object over time
            transform.Rotate(toRotation * Time.deltaTime * speed);
        }
    }

    IEnumerator Rotate()
    {
        if (rotateType == RotateType.Fixed)
        {
            Vector3 newRot = rotated ? startRotation : toRotation;
            var toAngle = Quaternion.Euler(newRot);
            while (transform.rotation != toAngle)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toAngle, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
            rotated = !rotated;
            StartCoroutine(Rotate());
        }
    }
}
