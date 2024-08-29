using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Sw4rmerScript : MonoBehaviour
{
    public Rigidbody2D rigidSelf;
    public float moveSpeed;
    public bool movingDown;
    private int horiNum;
    public float timerMax;
    private float timer;
    public GameObject laser;
    public float health;
    public UIControllerScript uiScript;
    public GameObject Sw4rmer;
    private GameObject child;
    public Sprite normal;
    public Sprite prepare;
    public Sprite shoot;
    public GameObject death;

    public List<GameObject> powerUps;
    //public GameObject[] itemDrops;

    private AudioSource audioSource;
    public AudioClip enemyHit;

    // Start is called before the first frame update
    void Start()
    {
        timerMax += Random.Range(-2f, 2f);
        timer = timerMax;
        rigidSelf = this.GetComponent<Rigidbody2D>();
        uiScript = Camera.main.GetComponent<UIControllerScript>();
        child = this.transform.GetChild(0).gameObject;
        audioSource = GetComponent<AudioSource>();
    }

  

    // Update is called once per frame
    void Update()   
    {
        if (movingDown)
        {
            rigidSelf.velocity = new Vector2(0, 1) * -1 * moveSpeed;
        }
        else if (!movingDown)
        {
            rigidSelf.velocity = new Vector2(0, 1) * moveSpeed;
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            StartCoroutine(fire());
            timer = timerMax;
        }

        if (health <= 0)
        {
            int up = Random.Range(1, 21);
            if(up == 1)
            {
                int power = Random.Range(0, 3);
                Instantiate(powerUps[power], transform.position, Quaternion.Euler(0, 0, 0));
            }
            uiScript.score += 50;
            Instantiate(death, transform.position, Quaternion.identity);
            Destroy(gameObject);      
        }


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        int temp = Random.Range(0, 2);
        if (temp == 0)
        {
            horiNum = -1;
        }
        else
        {
            horiNum = -2;
        }
        if (col.gameObject.tag == "Topwall")
        {
            movingDown = true;
            transform.position = new Vector3(transform.position.x + horiNum, transform.position.y, transform.position.z);
        }
        else if (col.gameObject.tag == "Bottomwall")
        {
            movingDown = false;
            transform.position = new Vector3(transform.position.x + horiNum, transform.position.y, transform.position.z);
        }
        else if (col.collider.tag == "Laser")
        {
            health = health - 1;
            audioSource.PlayOneShot(enemyHit);
            print ("oh no");
        }
    }

    private void OnDestroy()
    {
        if (Sw4rmer.gameObject == null)
        {
            Debug.Log("let's go");
        }
    }

    IEnumerator fire()
    {
        child.GetComponent<SpriteRenderer>().sprite = prepare;
        yield return new WaitForSeconds(0.5f);
        child.GetComponent<SpriteRenderer>().sprite = shoot;
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(0.5f);
        child.GetComponent<SpriteRenderer>().sprite = normal;
    }
        //private void ItemDrop()
        //{
        //  for (int i = 0; i < itemDrops.Length; i++)
        //{
        //  Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        //}
        //}
 }
