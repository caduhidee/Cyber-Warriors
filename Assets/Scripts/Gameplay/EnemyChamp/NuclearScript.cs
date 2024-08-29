using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearScript : MonoBehaviour
{
    private GameObject player;
    public GameObject laser;
    public float speed;
    public float health;
    public UIControllerScript uiScript;
    public List<GameObject> powerUps;
    public Sprite prepare;
    public GameObject deathObj;
    public float curveOveride;
    private float timer = 4;
    private float timer2 = 2;
    private GameObject tempLaser;
    private GameObject radiation;
    
    private AudioSource audioSource;
    public AudioClip enemyHit;

    //public GameObject[] itemDrops;

    // Start is called before the first frame update
    void Start()
    {
        radiation = transform.GetChild(0).gameObject;
        radiation.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        uiScript = Camera.main.GetComponent<UIControllerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        if ((health <= 40) & (health > 0))
        {
            GetComponent<SpriteRenderer>().sprite = prepare;
            speed = 0.1f;
            GetComponent<Animator>().enabled = false;
            timer -= Time.deltaTime;
            if (timer <= 3)
            {
                radiation.SetActive(true);
                radiation.transform.localScale = new Vector3(Random.Range(1.45f, 1.55f), Random.Range(1.45f, 1.55f), Random.Range(1.45f, 1.55f));
                if (timer <= 0)
                {
                    curveOveride = -curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 0));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 36));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 72));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 108));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 144));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 180));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 216));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 252));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 288));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 324));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 360));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    timer = 2;
                }
            }
        }
        else
        {
            timer2 -= Time.deltaTime;
            if (timer2 <= 0)
            {
                timer2 = 2;
                tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
                tempLaser.GetComponent<CurveLaserScript>().curveRate = Random.Range(-90f, 90f);
                tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
                tempLaser.GetComponent<CurveLaserScript>().curveRate = Random.Range(-90f, 90f);
                tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
                tempLaser.GetComponent<CurveLaserScript>().curveRate = Random.Range(-90f, 90f);
            }
        }
        if (health <= 0)
        {
            Instantiate(deathObj, transform.position, Quaternion.identity);
            GetComponent<Animator>().enabled = false;
            int up = Random.Range(1, 6);
            if (up == 1)
            {
                int power = Random.Range(0, 3);
                Instantiate(powerUps[power], transform.position, Quaternion.Euler(0, 0, 0));
            }
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 0));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = 150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 36));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = -150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 72));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = 150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 108));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = -150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 144));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = 150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 180));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = -150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 216));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = 150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 252));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = -150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 288));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = 150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 324));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = -150;
            tempLaser = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 360));
            tempLaser.GetComponent<CurveLaserScript>().curveRate = 150;
            Destroy(gameObject);
            uiScript.score += 1000;
        }
        

        //ItemDrop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Laser")
        {
            health = health - 1;
            audioSource.PlayOneShot(enemyHit);
            print("oh no");
            if (health < 0)
            {
                health = 0;
            }
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