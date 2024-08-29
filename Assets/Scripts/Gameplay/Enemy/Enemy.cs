using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public GameObject laserPrefab;
    public GameObject Sw4rmer;
    //public AudioSource audioSource;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 2.5f, 2.5f);
        //uiScript = GameObject.FindWithTag("GameController").GetComponent<UIControllerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle - 90));
    }

    private void Shoot()
    {
        GameObject lastLaser = Instantiate(laserPrefab, transform.position, transform.localRotation);
        //audioSource.Play();
    }

    private void OnDestroy()
    {
        if (Sw4rmer.gameObject == null)
        {
            Debug.Log("let's go");
        }
    }

    //    private void OnCollisionEnter2D(Collision2D collision)
    //    {
    //        //if (collision.collider.tag == "Player")
    //        //{
    //        //    uiScript.score += 100;
    //        //    Destroy(gameObject);
    //        //}
    //        /*else*/ if (collision.collider.tag == "Laser")
    //        {
    //            //if (collision.collider.GetComponent<LaserScript>().IFF == "P1")
    //            //{
    //            //    uiScript.score += 100;
    //            //    Destroy(gameObject);
    //            //}
    //            uiScript.score += 100;
    //            Destroy(gameObject);
    //        }
    //    }
}
