using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampDefeat : MonoBehaviour
{
    public GameObject deathObj;
    public bool shatter;
    public GameObject shatterObjA;
    public GameObject shatterObjB;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(death());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator death()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(deathObj, transform.position, Quaternion.identity);
        if(shatter)
        {
            Instantiate(shatterObjA, transform.position, Quaternion.identity);
            Instantiate(shatterObjB, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
