using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class beam : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootForce = 100f;
    public float speed = 20f;
    public Rigidbody2D rb;
    Shooter shoot;
    public GameObject beamHitbox;

    private float xVel;
    private float yVel;
    public int time;

    private bool once = false;
    LineRenderer line;

    int layerMask = 1 << 3;

    private void Start()
    {
        layerMask = ~layerMask;
        shoot = GameObject.Find("Player").GetComponent<Shooter>();
        line = gameObject.GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (shoot.currPower == "beam")
        {
            if (!once) 
            { 
                Instantiate(beamHitbox, transform.position, Quaternion.identity, transform); 
                StartCoroutine(cd()); 
                once = true; 
            }
                
            line.SetPosition(0, new Vector3(0, 150, 0));
            
            
        }
    }

    IEnumerator cd()
    {
        
        yield return new WaitForSeconds(5);
        shoot.currPower = "normal";
        line.SetPosition(0, new Vector3(0, 0, 0));
        Destroy(transform.GetChild(4).gameObject);
        once = false;

    }

}
