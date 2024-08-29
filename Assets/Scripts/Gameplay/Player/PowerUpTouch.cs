using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpTouch : MonoBehaviour
{
    private GameObject player;
    private float yVal;
    public float pathHeight;
    private float yStart;
    public int moveSpeed;
    public string powerUpType; //Here type what powerUp it is (all lowercase, only letters)

    void Start()
    {
        yStart = transform.position.y;
    }
    void Update()
    {
        yVal = (Mathf.Sin(transform.position.x) * pathHeight) + yStart;
        transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime), yVal, transform.position.z);
        transform.Translate(Vector2.left * 0.005f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject;
            player.GetComponent<Shooter>().currPower = powerUpType;
            player.GetComponent<Player>().Switch = true;
            Destroy(gameObject);
        }
    }
}
