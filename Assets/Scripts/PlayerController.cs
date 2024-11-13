using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;
    private int pickupCount;
    private Timer timer;
    private bool gameOver = false;
    private int totalPickups;
    private float pickupChunk;

    GameObject resetPoint;
    bool resetting = false;
    Color originalColor;

    [Header("UI")]
    public TMP_Text pickupText;
    public TMP_Text timerText;
    public Image pickupImage;
    public TMP_Text winTimeText;
    public GameObject inGamePanel;
    public GameObject winPanel;

    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;
    public AudioClip winMusic;
    public AudioClip pickupGet;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the RigidBody component attached to this gameObject
        rb = GetComponent<Rigidbody>();
        //Get the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //Assign the total amount of pickups
        totalPickups = pickupCount;

        //Resetting fillAmount
        pickupImage.fillAmount = 0;
        //Fill according to amount of Pickups in the stage
        pickupChunk = 1.0f / pickupCount;

        resetPoint = GameObject.Find("Reset Point");
        originalColor = GetComponent<Renderer>().material.color;

        //Run the CheckPickups() function
        CheckPickups();
        //Gets the timer Object
        timer = FindObjectOfType<Timer>();
        //Start timer
        timer.StartTimer();
        //Turn off Win Panel & Turn on In-Game Panel
        winPanel.SetActive(false);
        inGamePanel.SetActive(true);
        //Return game state
        gameOver = false;
    }

    private void Update()
    {
        timerText.text = "Time: " + timer.currentTime.ToString("F2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (resetting)
            return;
        if (gameOver == true)
            return;

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
            //Play pickupGet sound
            sfxPlayer.Play();
            //Destroy collided object
            Destroy(other.gameObject);
            //Decrement pickupCount
            pickupCount--;
            //Fill pickupImage
            pickupImage.fillAmount = pickupImage.fillAmount + pickupChunk;
            //Run CheckPickups() function again
            CheckPickups();
        }
    }

    private void CheckPickups()
    {
        //print("Pickups left: " + pickupCount);
        pickupText.text = ("Pickups left: " + pickupCount);
        pickupText.color = Color.yellow;

        if (pickupCount == 0)
        {
            timer.StopTimer();
            WinGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }
    }

    private void WinGame()
    {
        //pickupText.color = Color.green;
        inGamePanel.SetActive(false);
        winPanel.SetActive(true);
        gameOver = true;
        //print("CONGRATULATIONS!!! Your time was: " + timer.GetTime().ToString("F2"));
        winTimeText.text = "Your time was: " + timer.GetTime().ToString("F2");

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        bgmPlayer.clip = winMusic;
        bgmPlayer.Play();
    }

    public IEnumerator ResetPlayer()
    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        float resetSpeed = 2f;
        var i = 0f;
        var rate = 1.0f / resetSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, resetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalColor;
        resetting = false;
    }

    //Temporary Restart Function
    public void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
