using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript1 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private float xVel;
    private float yVel;
    public int time;
    [SerializeField] private float shootForce; // Force with which to shoot the projectile

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shootForce, ForceMode2D.Impulse);



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

