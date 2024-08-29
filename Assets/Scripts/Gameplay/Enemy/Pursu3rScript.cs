using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursu3rScript : MonoBehaviour
{
    public GameObject player;
    public GameObject laser;
    public float speed;
    public float spacing;
    public float timerMax;
    private float timer;
    private float time;
    private Vector3 sin;
    private float randX;
    private float randY;
    public float health;
    public List<GameObject> powerUps;
    //public GameObject[] itemDrops;
    public UIControllerScript uiScript;
    public Sprite normal;
    public Sprite fear;
    public Sprite attack;
    private bool attacking = false;
    public GameObject death;
    private GameObject child;

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
        sin = new Vector3(Mathf.Sin(time * randX) / 2, Mathf.Sin(time * randY), 0) / 2;
        child.transform.position = sin + transform.position;

        if (transform.position.x >= (player.transform.position.x + spacing - 0.2f))
        {
            if (!attacking)
            {
                child.GetComponent<SpriteRenderer>().sprite = normal;
            }
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0f)
            {
                Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 65));
                Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 90));
                Instantiate(laser, child.transform.position, Quaternion.Euler(0, 0, 115));
                timer = timerMax;
                attacking = true;
                StartCoroutine(fire());
            }
        }
        else
        {
            if (!attacking)
            {
                child.GetComponent<SpriteRenderer>().sprite = fear;
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
            print ("oh no");

        }
    }
    IEnumerator fire()
    {
        child.GetComponent<SpriteRenderer>().sprite = attack;
        yield return new WaitForSeconds(0.5f);
        child.GetComponent<SpriteRenderer>().sprite = normal;
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
