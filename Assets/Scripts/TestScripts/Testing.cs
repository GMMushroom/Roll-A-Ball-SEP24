using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public int health = 100;
    public int cannonDamage = 80;
    public int rockDamage = 30;
    public int pebbleDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(15);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(5);
        }
    }

    private void TakeDamage(int _damage)
    {
        health -= _damage;

        if (health <= 0)
        { 
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        print("You Died");
        Destroy(gameObject,1);
    }

    private void ChangeColour(Color _color)
    {
        GetComponent<Renderer>().material.color = _color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Cannon")
        {
            TakeDamage(cannonDamage);
            ChangeColour(Color.black);
        }
        if (collision.gameObject.name == "Rock")
        {
            TakeDamage(rockDamage);
            ChangeColour(Color.blue);
        }
        if (collision.gameObject.name == "Pebble")
        {
            TakeDamage(pebbleDamage);
            ChangeColour(Color.red);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //TakeDamage(10);
    }

    private void OnCollisionStay(Collision collision)
    {
        //TakeDamage(1);
    }
}
