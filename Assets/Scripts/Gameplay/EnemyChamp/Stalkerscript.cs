using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalkerscript : MonoBehaviour
{
    public GameObject player;
    public GameObject laser;
    public float speed;
    public float spacing;
    public float timerMax;
    public float curveOveride;
    private float timer;
    private float timer2;
    private float time;
    private Vector3 sin;
    private float randX;
    private float randY;
    public float health;
    public List<GameObject> powerUps;
    //public GameObject[] itemDrops;
    public UIControllerScript uiScript;
    public Sprite fear;
    public Sprite attack;
    public Sprite flurry;
    private bool attacking = false;
    public GameObject death;
    private GameObject child;
    private GameObject tempLaser;

    private AudioSource audioSource;
    public AudioClip enemyHit;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        timer = timerMax;
        uiScript = Camera.main.GetComponent<UIControllerScript>();
        audioSource = GetComponent<AudioSource>();
        randX = Random.Range(5f, 7f);
        randY = Random.Range(5f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 movePos = new Vector3(player.transform.position.x + spacing, player.transform.position.y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, movePos, step);

        time += Time.deltaTime;
        sin = new Vector3(Mathf.Sin(time * randX), Mathf.Sin(time * randY), 0);

        if (transform.position.x >= (player.transform.position.x + spacing - 0.2f))
        {
            speed = 6;
            if (attacking)
            {
                child.GetComponent<Animator>().enabled = false;
            }
            else if (!attacking)
            {
                child.GetComponent<Animator>().enabled = true;
            }
            child.transform.position = sin + transform.position;
            timer2 = 1;
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0f)
            {
                if(Random.Range(0,2) == 0)
                {
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 50));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 60));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 70));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = curveOveride;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 110));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = -curveOveride;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 120));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = -curveOveride;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 130));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = -curveOveride;
                    timer = timerMax;
                    attacking = true;
                    StartCoroutine(fire());
                }
                else
                {
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 95));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = -20;
                    tempLaser.GetComponent<CurveLaserScript>().speed = 15;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 100));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = -20;
                    tempLaser.GetComponent<CurveLaserScript>().speed = 15;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 105));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = -20;
                    tempLaser.GetComponent<CurveLaserScript>().speed = 15;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 85));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = 20;
                    tempLaser.GetComponent<CurveLaserScript>().speed = 15;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 80));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = 20;
                    tempLaser.GetComponent<CurveLaserScript>().speed = 15;
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 75));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = 20;
                    tempLaser.GetComponent<CurveLaserScript>().speed = 15;
                    timer = timerMax;
                    attacking = true;
                    StartCoroutine(fire());
                }
            }
        }
        else
        {
            child.GetComponent<Animator>().enabled = false;
            child.transform.position = transform.position;
            child.GetComponent<SpriteRenderer>().sprite = fear;
            timer2 -= Time.deltaTime;
            if (timer2 <= 0.1f)
            {
                child.GetComponent<SpriteRenderer>().sprite = flurry;
                speed = 10;
                if (timer2 <= 0)
                {
                    tempLaser = Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, Random.Range(50f, 130f)));
                    tempLaser.GetComponent<CurveLaserScript>().curveRate = 0;
                    timer2 = 0.05f;
                }
            }
            else
            {
                speed = 1f;
            }
        }

        if (health <= 0)
        {
            int up = Random.Range(1, 11);
            if (up == 1)
            {
                int power = Random.Range(0, 3);
                Instantiate(powerUps[power], child.transform.position, Quaternion.Euler(0, 0, 0));
            }
            Instantiate(death, child.transform.position, Quaternion.identity);
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
            print("oh no");

        }
    }
    IEnumerator fire()
    {
        child.GetComponent<Animator>().enabled = false;
        child.GetComponent<SpriteRenderer>().sprite = attack;
        yield return new WaitForSeconds(0.5f);
        child.GetComponent<Animator>().enabled = true;
        child.GetComponent<SpriteRenderer>().sprite = null;
        attacking = false;
    }
    //private void ItemDrop()
    //{
    //  for (int i = 0; i < itemDrops.Length; i++)
    //{
    //  Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    //}
    //}
}
