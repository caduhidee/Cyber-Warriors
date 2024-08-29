using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Sp1ralScript : MonoBehaviour
{
    public int rotSpeed;
    public int moveSpeed;
    public float health;
    public UIControllerScript uiScript;
    public List<GameObject> powerUps;
    public GameObject death;
    //public GameObject[] itemDrops;

    private AudioSource audioSource;
    public AudioClip enemyHit;

    private void Start()
    {
        uiScript= Camera.main.GetComponent<UIControllerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        if (health <= 0)
        {
            int up = Random.Range(1, 31);
            if (up == 1)
            {
                int power = Random.Range(0, 3);
                Instantiate(powerUps[power], transform.position, Quaternion.Euler(0, 0, 0));
            }
            Instantiate(death, transform.position, Quaternion.identity);
            Destroy(gameObject);
            uiScript.score += 100;
        }

        //ItemDrop();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Laser")
        {
            health = health - 1;
            audioSource.PlayOneShot(enemyHit);
            print ("oh no");
        }

        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            uiScript.score += 100;
        }
    }

    //private void ItemDrop()
    //{
    //  for (int i = 0; i < itemDrops.Length; i++)
    //{
    //  Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    //}
    //}
}
