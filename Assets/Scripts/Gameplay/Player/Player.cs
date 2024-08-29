using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  : MonoBehaviour
{
    public float speed = 5f;
    
    private Rigidbody2D rb;
   
    public int health;
    public int lives;

    public AudioClip powerUpSound;
    private AudioSource audioSource;
    public AudioClip playerDeath;
    public AudioClip playerHit;

    private SpriteRenderer rend;

    private GameObject backBoostA;
    private GameObject backBoostB;
    private GameObject sideBoostA;
    private GameObject sideBoostB;

    Shooter shooter;
    
    public Sprite boomerangSprite;
    public Sprite triShotSprite;
    public Sprite beamSprite;
    public Sprite normalSprite;

    public GameObject particleEffect;
    public bool Switch = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = gameObject.GetComponent<SpriteRenderer>();
        shooter = GameObject.Find("Player").GetComponent<Shooter>();
        audioSource = GetComponent<AudioSource>();
        backBoostA = transform.GetChild(0).gameObject;
        backBoostB = transform.GetChild(1).gameObject;
        sideBoostA = transform.GetChild(2).gameObject;
        sideBoostB = transform.GetChild(3).gameObject;
    }

    //movement script section
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(transform.position.x + (moveHorizontal * speed), transform.position.y + (moveVertical * speed));

        transform.position = movement;
       
        if (health == 0)
        {
            audioSource.PlayOneShot(playerDeath);
            print("you are dead");
            Destroy(gameObject);
        }

        //Back Booster Animation Script
        if (moveHorizontal > 0.05f)
        {
            backBoostA.GetComponent<SpriteRenderer>().enabled = false;
            backBoostB.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (moveHorizontal < -0.05f)
        {
            backBoostA.GetComponent<SpriteRenderer>().enabled = false;
            backBoostB.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            backBoostB.GetComponent<SpriteRenderer>().enabled = false;
            backBoostA.GetComponent<SpriteRenderer>().enabled = true;
        }

        //Side Booster Animation Script
        if (moveVertical > 0.05f)
        {
            sideBoostA.GetComponent<SpriteRenderer>().enabled = false;
            sideBoostB.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (moveVertical < -0.05f)
        {
            sideBoostA.GetComponent<SpriteRenderer>().enabled = true;
            sideBoostB.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            sideBoostA.GetComponent<SpriteRenderer>().enabled = false;
            sideBoostB.GetComponent<SpriteRenderer>().enabled = false;
        }

        SpriteChanger();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(playerHit);
            print ("i have been hit");
            health = health - 1;
            Destroy(Instantiate(particleEffect, transform.position, Quaternion.Euler(0, 0, 0), null), 1);
        }

        if (collision.gameObject.tag == "EnemyLaser")
        {
            audioSource.PlayOneShot(playerHit);
            print ("i have been hit again");
            health = health - 1;
            Destroy(Instantiate(particleEffect, transform.position, Quaternion.Euler(0, 0, 0), null), 1);
        }

        
        Debug.Log("oof");

    }

    void SpriteChanger()
    {

        if (shooter.normal == true)
        {
            rend.sprite = normalSprite;
        }

        else if (shooter.beam == true && Switch)
        {
            rend.sprite = beamSprite;
            audioSource.PlayOneShot(powerUpSound);
            Switch = false;
        }

        else if (shooter.boomerang == true && Switch)
        {
            rend.sprite = boomerangSprite;
            audioSource.PlayOneShot(powerUpSound);
            Switch = false;
        }

        else if (shooter.triShot == true && Switch)
        {
            rend.sprite = triShotSprite;
            audioSource.PlayOneShot(powerUpSound);
            Switch = false;
        }
    }
}