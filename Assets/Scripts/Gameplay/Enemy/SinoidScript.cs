using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinoidScript : MonoBehaviour
{
    public int moveSpeed;
    public int pathHeight;
    public float health;
    private float yVal;
    private float yStart;
    public GameObject player;
    public GameObject laser;
    private bool canSpawn = true;
    public List<GameObject> powerUps;
    //public GameObject[] itemDrops;
    public UIControllerScript uiScript;
    public Sprite up;
    public Sprite down;
    public GameObject death;

    private AudioSource audioSource;
    public AudioClip enemyHit;

    // Start is called before the first frame update
    void Start()
    {
        yStart = transform.position.y;
        uiScript = Camera.main.GetComponent<UIControllerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        yVal = (Mathf.Sin(transform.position.x) * pathHeight) + yStart;
        transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime), yVal, transform.position.z);
        if ((Mathf.Sin(transform.position.x) <= -0.9) | (Mathf.Sin(transform.position.x) >= 0.9))
        {
            if (canSpawn)
            {
                canSpawn = false;
                GameObject child = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 90));
                if (Mathf.Sin(transform.position.x) <= -0.9)
                {
                    GetComponent<SpriteRenderer>().sprite = up;
                }
                else if (Mathf.Sin(transform.position.x) >= 0.9)
                {
                    GetComponent<SpriteRenderer>().sprite = down;
                }
            }
        }
        else
        {
            canSpawn = true;
        }

        if (health <= 0)
        {
            int up = Random.Range(1, 9);
            if (up == 1)
            {
                int power = Random.Range(0, 3);
                Instantiate(powerUps[power], transform.position, Quaternion.Euler(0, 0, 0));
            }
            Instantiate(death, transform);
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
    }

    //private void ItemDrop()
    //{
    //  for (int i = 0; i < itemDrops.Length; i++)
    //{
    //  Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    //}
    //}
}