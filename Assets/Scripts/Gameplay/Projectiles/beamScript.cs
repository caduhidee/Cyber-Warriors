using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private float xVel;
    private float yVel;
    public int time;
    beam shooting;
    private void Start()
    {

        shooting = GameObject.Find("Player").GetComponent<beam>();
        rb = GetComponent<Rigidbody2D>();

        yVel = Mathf.Sin((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;
        xVel = Mathf.Cos((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;

        rb.velocity = new Vector2(xVel, yVel);
    }


    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, time);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
