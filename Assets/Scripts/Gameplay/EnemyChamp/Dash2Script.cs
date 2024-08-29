using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash2Script : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private GameObject player;

    private float xVel;
    private float yVel;
    private Vector2 vect;
    public int time;
    private float timer = 0.4f;
    public GameObject trail;
    private GameObject tempObj;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        yVel = Mathf.Sin((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;
        xVel = Mathf.Cos((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;

        vect = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        vect = (vect / Vector2.Distance(player.transform.position, transform.position)) * speed;
        rb.velocity = vect;
        float angle = (Mathf.Atan2(vect.y, vect.x) * Mathf.Rad2Deg) - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            tempObj = Instantiate(trail, transform.position, Quaternion.identity);
            Destroy(tempObj, 2);
            timer = 0.4f;
        }
        rb.velocity = vect;
        Destroy(this.gameObject, time);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}