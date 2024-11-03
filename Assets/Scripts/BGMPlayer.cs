using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    private AudioSource bgmPlayer;
    public AudioClip stage1Music;
    public string stage = "Level1";

    // Start is called before the first frame update
    void Start()
    {
        bgmPlayer = GetComponent<AudioSource>();

        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == stage)
        {
            bgmPlayer.clip = stage1Music;
            bgmPlayer.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
