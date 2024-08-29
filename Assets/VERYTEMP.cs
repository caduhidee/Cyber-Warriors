using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VERYTEMP : MonoBehaviour
{
    private float time;
    private float randX;
    private float randY;
    private Vector3 sin;
    private GameObject child;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        randX = Random.Range(5f, 7f);
        randY = Random.Range(5f, 7f);
        child = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float step = 4 * Time.deltaTime;
        Vector3 movePos = new Vector3(player.transform.position.x + 15, player.transform.position.y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, movePos, step);

        time += Time.deltaTime;
        sin = new Vector3(Mathf.Sin(time * randX) / 2, Mathf.Sin(time * randY), 0) / 2;
        child.transform.position = sin + transform.position;

    }
}
