using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempEnemySpawner : MonoBehaviour
{
    public bool debugActive;
    private int spawning = 0;
    private int count = 0;
    public float yMax;
    public float yMin;
    public float xPos;
    private float spawnNum;
    private Vector3 spawnVect;
    private Vector3 tempVect;

    public GameObject swarmer;
    public GameObject unstable;
    public GameObject spiral;
    public GameObject pursuer;
    public GameObject sinoid;
    public GameObject arcSinoid;
    public GameObject nuclear;
    public GameObject stalker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            spawning = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            spawning = 2;
        }
        if (Input.GetKeyDown("3"))
        {
            spawning = 3;
        }
        if (Input.GetKeyDown("4"))
        {
            spawning = 4;
        }
        if (Input.GetKeyDown("5"))
        {
            spawning = 5;
        }
        if (Input.GetKeyDown("6"))
        {
            spawning = 6;
        }
        if (Input.GetKeyDown("7"))
        {
            spawning = 7;
        }
        if (Input.GetKeyDown("8"))
        {
            spawning = 8;
        }


        if (spawning != 3)
        {
            spawnNum = Random.Range(yMin, yMax);
            spawnVect = new Vector3(xPos, spawnNum, 0);
        }
        if (count >= 10)
        {
            CancelInvoke("spawnSpirals");
        }
        if (debugActive)
        {
            switch (spawning)
            {
                case 1:
                    spawnNum = Random.Range(yMin + 6, yMax);
                    spawnVect = new Vector3(xPos, spawnNum, 0);
                    Instantiate(swarmer, spawnVect, Quaternion.Euler(0, 0, 0));
                    for (int i = 0; i < 4; i++)
                    {
                        spawnNum -= 1.5f;
                        spawnVect = new Vector3(xPos, spawnNum, 0);
                        Instantiate(swarmer, spawnVect, Quaternion.Euler(0, 0, 0));
                    }
                    spawning = 0;
                    break;
                case 2:
                    Instantiate(unstable, spawnVect, Quaternion.Euler(0, 0, 0));
                    spawning = 0;
                    break;
                case 3:
                    tempVect = spawnVect;
                    InvokeRepeating("spawnSpirals", 0f, .5f);
                    spawning = 0;
                    break;
                case 4:
                    Instantiate(pursuer, spawnVect, Quaternion.Euler(0, 0, 0));
                    spawning = 0;
                    break;
                case 5:
                    spawnNum = Random.Range(yMin + 2, yMax - 2);
                    spawnVect = new Vector3(xPos, spawnNum, 0);
                    Instantiate(sinoid, spawnVect, Quaternion.Euler(0, 0, 0));
                    spawning = 0;
                    break;
                case 6:
                    Instantiate(arcSinoid, transform.position + new Vector3(-5, 0, 0), Quaternion.Euler(0, 0, 0));
                    spawning = 0;
                    break;
                case 7:
                    Instantiate(nuclear, transform.position + new Vector3(-5, 0, 0), Quaternion.Euler(0, 0, 0));
                    spawning = 0;
                    break;
                case 8:
                    Instantiate(stalker, transform.position + new Vector3(-5, 0, 0), Quaternion.Euler(0, 0, 0));
                    spawning = 0;
                    break;
            }
        }
    }

    void spawnSpirals()
    {
        Instantiate(spiral, tempVect, Quaternion.Euler(0, 0, 0));
        count++;
    }
}
