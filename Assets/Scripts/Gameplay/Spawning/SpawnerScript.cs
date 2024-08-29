using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
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

    public float waitMin;
    public float waitMax;
    public float startBuffer;
    public float decayBuffer;
    private float time;
    private int waveBonus;
    private float waitTime;
    private int randEnemy;

    public GameObject swarmer;
    public int swarmerBound;
    public GameObject unstable;
    public int unstableBound;
    public GameObject spiral;
    public int spiralBound;
    public GameObject pursuer;
    public int pursuerBound;
    public GameObject sinoid;
    public int sinoidBound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        startBuffer -= (Time.deltaTime / decayBuffer);
        waitTime = Random.Range(waitMin + startBuffer, waitMax + startBuffer);
        time = time + Time.deltaTime;
        //Debug.Log(time);

        if (time < 30)
        {
            waveBonus = 0;
        }
        else if (time < 90)
        {
            waveBonus = 3;
        }
        else
        {
            waveBonus = 6;
        }

        if (spawning != 3)
        {
            spawnNum = Random.Range(yMin, yMax);
            spawnVect = new Vector3(xPos, spawnNum, 0);
        }
        if (count >= 6 + waveBonus)
        {
            CancelInvoke("spawnSpirals");
            count = 0;
        }
        if (debugActive)
        {
            switch (spawning)
            {
                case 1:
                    spawnNum = Random.Range(yMin + 6, yMax);
                    spawnVect = new Vector3(xPos, spawnNum, 0);
                    Instantiate(swarmer, spawnVect, Quaternion.Euler(0, 0, 0));
                    for (int i = 0; i < (2 + waveBonus); i++)
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
            }
        }
    }

    void spawnSpirals()
    {
        Instantiate(spiral, tempVect, Quaternion.Euler(0, 0, 0));
        count++;
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(4);

        while(true)
        {
            randEnemy = Random.Range(1,22);
            if(randEnemy <= spiralBound)
            {
                spawning = 3;
            }
            else if (randEnemy <= swarmerBound + spiralBound)
            {
                spawning = 1;
            }
            else if (randEnemy <= pursuerBound + swarmerBound + spiralBound)
            {
                spawning = 4;
            }
            else if (randEnemy <= unstableBound + pursuerBound + swarmerBound + spiralBound)
            {
                spawning = 2;
            }
            else if (randEnemy == sinoidBound + unstableBound + pursuerBound + swarmerBound + spiralBound)
            {
                spawning = 5;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
