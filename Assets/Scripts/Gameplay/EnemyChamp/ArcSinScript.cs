using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcSinScript : MonoBehaviour
{
    public float moveSpeed;
    public int pathHeight;
    public float health;
    private float yVal;
    private float yStart;
    private float time;
    public GameObject player;
    public GameObject laser;
    private bool canSpawn = true;
    public List<GameObject> powerUps;
    //public GameObject[] itemDrops;
    public UIControllerScript uiScript;
    public Sprite up;
    public Sprite down;
    public GameObject death;
    private GameObject child1;
    private GameObject child2;
    private GameObject child3;
    private GameObject child4;
    private float rand1;
    private float rand2;
    private float rand3;
    private float rand4;

    private AudioSource audioSource;
    public AudioClip enemyHit;

    // Start is called before the first frame update
    void Start()
    {
        child1 = transform.GetChild(0).gameObject;
        child2 = transform.GetChild(1).gameObject;
        child3 = transform.GetChild(2).gameObject;
        child4 = transform.GetChild(3).gameObject;
        rand1 = Random.Range(2f, 3f);
        rand2 = Random.Range(2f, 3f);
        rand3 = Random.Range(2f, 3f);
        rand4 = Random.Range(2f, 3f);
        yStart = transform.position.y;
        uiScript = Camera.main.GetComponent<UIControllerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        child1.transform.position = (new Vector3(Mathf.Sin((time * 6) + 4), Mathf.Cos((time * 6) - 2), 0) * rand1) + transform.position;
        child2.transform.position = (new Vector3(Mathf.Sin((time * 6) + 7), Mathf.Cos((time * 6) + 9), 0) * rand2) + transform.position;
        child3.transform.position = (new Vector3(Mathf.Sin((time * 6) - 12), Mathf.Cos((time * 6) + 20), 0) * rand3) + transform.position;
        child4.transform.position = (new Vector3(Mathf.Sin((time * 6) + 14), Mathf.Cos((time * 6) + 6), 0) * rand4) + transform.position;

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
            print("oh no");
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