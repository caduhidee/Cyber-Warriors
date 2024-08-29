using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerangScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float speedDecay;

    private float xVel;
    private float yVel;
    public int time;
    private float lifetime;
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        //yVel = Mathf.Sin((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;
        xVel = Mathf.Cos((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed;

        rb.velocity = new Vector2(xVel, yVel);

        //AudioSource audioSource = GetComponent<AudioSource>();
        //audioSource.pitch = Random.Range(0.8f, 1.5f);
        //audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        //yVel = (Mathf.Sin((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed);
        //xVel = (Mathf.Cos((transform.rotation.eulerAngles.z * Mathf.Deg2Rad) + Mathf.PI / 2) * speed) / speedDecay;
        if (xVel >= 0)
        {
            xVel = xVel - (speedDecay * Time.deltaTime);
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        transform.localScale += new Vector3(Time.deltaTime * 1.5f, Time.deltaTime * 1.5f, 0);

        rb.velocity = new Vector2(xVel, yVel);
        Destroy(this.gameObject, time);
    }
}
