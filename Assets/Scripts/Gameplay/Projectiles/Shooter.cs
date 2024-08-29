using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Prefab of the projectile
    [SerializeField] private GameObject boomerangPrefab; // Prefab of the boomerang
    [SerializeField] private float shootForce = 100f; // Force with which to shoot the projectile
    public string currPower = "normal";
    private LineRenderer line;
    //public GameObject[] itemDrops;
    public bool boomerang = false;
    public bool beam = false;
    public bool triShot = false;
    public bool normal = true;
    private bool canShoot = true;

    public AudioClip trishot;
    private AudioSource audioSource;

    public float normalShotRate;
    public float boomerangShotRate;
    public float beamShotRate;
    public float triShotRate;

    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currPower == "normal")
            {
                if (canShoot)
                {
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
                    StartCoroutine(cooldown(normalShotRate));
                }

            }
            else if(currPower == "trishot")
            {
                if (canShoot)
                {
                    GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(0.5f, 0, 0), transform.rotation);
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.right * shootForce, ForceMode2D.Impulse);

                    GameObject projectile2 = Instantiate(projectilePrefab, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
                    Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
                    rb2.AddForce(transform.right * shootForce, ForceMode2D.Impulse);

                    GameObject projectile3 = Instantiate(projectilePrefab, transform.position + new Vector3(0, -0.5f, 0), transform.rotation);
                    Rigidbody2D rb3 = projectile3.GetComponent<Rigidbody2D>();
                    rb3.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
                    StartCoroutine(cooldown(triShotRate));

                    audioSource.PlayOneShot(trishot);
                }
            }
            
            else if (currPower == "boomerang")
            {   
                if (canShoot)
                {
                    Instantiate(boomerangPrefab, transform.position, transform.rotation);
                    StartCoroutine(cooldown(boomerangShotRate));
                }
            }

        }

        SpriteChanger();

    }

    IEnumerator cooldown(float wait)
    {
        canShoot = false;
        yield return new WaitForSeconds(wait);
        canShoot = true;
    }
    IEnumerator Return()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shootForce + transform.up * shootForce, ForceMode2D.Force);
        yield return new WaitForSeconds(1);
        rb.velocity = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            if (rb != null)
            {
                rb.AddForce(transform.up * shootForce * -10, ForceMode2D.Force);
                yield return new WaitForSeconds(0.1f);
            }        
        }
        
        currPower = "normal";
    }
    
    void SpriteChanger()
    {
        if (currPower == "normal")
        {
            triShot = false;
            normal = true;
            boomerang = false;
            beam = false;

        }
        else if (currPower == "trishot")
        {
            triShot = true;
            normal = false;
            boomerang = false;
            beam = false;

        }

        else if (currPower == "boomerang")
        {

            triShot = false;
            normal = false;
            boomerang = true;
            beam = false;
        }

        else if (currPower == "beam")
        {
            triShot = false;
            normal = false;
            boomerang = false;
            beam = true;
        }
    }
    
    //private void ItemDrop()
    //{
    //  for (int i = 0; i < itemDrops.Length; i++)
    //{
    //  Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    //}
    //}
}
