using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveLaserScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private float xVel;
    private float yVel;
    public int time;

    public float curveRate;
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        yVel = Mathf.Sin((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;
        xVel = Mathf.Cos((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;

        rb.velocity = new Vector2(xVel, yVel);

        //AudioSource audioSource = GetComponent<AudioSource>();
        //audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        yVel = Mathf.Sin((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;
        xVel = Mathf.Cos((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;

        rb.velocity = new Vector2(xVel, yVel);
        transform.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, curveRate * Time.deltaTime);
        Destroy(this.gameObject, time);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}