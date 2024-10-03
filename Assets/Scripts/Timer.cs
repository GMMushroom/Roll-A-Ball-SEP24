using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    private bool isTiming;
    
    // Update is called once per frame
    void Update()
    {
        if (isTiming == true)
        {
            currentTime += Time.deltaTime;
        }
    }

    public float GetTime()
    {
        return currentTime;
    }

    public void StartTimer()
    {
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
    }
}
