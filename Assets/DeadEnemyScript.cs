using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(2f, 5f), Random.Range(-2f, 6f));
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
