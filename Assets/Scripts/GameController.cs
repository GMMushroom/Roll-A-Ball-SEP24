using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlType { Normal, Worldtilt }

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public ControlType controlType;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Toggles our control type between world tilt and normal
    public void ToggleWorldTilt(bool _tilt)
    {
        if (_tilt)
            controlType = ControlType.Worldtilt;
        else
            controlType = ControlType.Normal;
    }
}
