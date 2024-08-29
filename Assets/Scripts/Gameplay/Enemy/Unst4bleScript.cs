using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unst4bleScript : MonoBehaviour
{
    private GameObject player;
    public GameObject laser;
    public float speed;
    public float health;
    public UIControllerScript uiScript;
    public List<GameObject> powerUps;
    public Sprite prepare;
    public GameObject deathObj;

    private AudioSource audioSource;
    public AudioClip enemyHit;

    //public GameObject[] itemDrops;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uiScript= Camera.main.GetComponent<UIControllerScript>();
        audioSource = GetComponent<AudioSource>();
    }   

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        if (health <= 0)
        {
            GetComponent<Animator>().enabled = false;
            StartCoroutine(death());
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
    IEnumerator death()
    {
        GetComponent<SpriteRenderer>().sprite = prepare;
        yield return new WaitForSeconds(0.5f);
        int up = Random.Range(1, 6);
        if (up == 1)
        {
            int power = Random.Range(0, 3);
            Instantiate(powerUps[power], transform.position, Quaternion.Euler(0, 0, 0));
        }
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 45));
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 135));
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 225));
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 270));
        Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 315));
        Instantiate(deathObj, transform.position, Quaternion.identity);
        Destroy(gameObject);
        uiScript.score += 1000;
    }
    //private void ItemDrop()
    //{
    //  for (int i = 0; i < itemDrops.Length; i++)
    //{
    //  Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    //}
    //}
}