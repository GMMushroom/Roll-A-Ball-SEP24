using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void ToLevelSelect()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void ToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }
}
