using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamHurt : MonoBehaviour
{
    public GameObject effect;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<Sw4rmerScript>() != null)
            {
                other.gameObject.GetComponent<Sw4rmerScript>().health -= 0.07f;
                Destroy(Instantiate(effect, other.gameObject.transform.position, Quaternion.Euler(0,0,0), null), 1);
            }
            if (other.gameObject.GetComponent<Sp1ralScript>() != null)
            {
                other.gameObject.GetComponent<Sp1ralScript>().health -= 0.07f;
                Destroy(Instantiate(effect, other.gameObject.transform.position, Quaternion.Euler(0, 0, 0), null), 1);
            }
            if (other.gameObject.GetComponent<Unst4bleScript>() != null)
            {
                other.gameObject.GetComponent<Unst4bleScript>().health -= 0.07f;
                Destroy(Instantiate(effect, other.gameObject.transform.position, Quaternion.Euler(0, 0, 0), null), 1);
            }
            if (other.gameObject.GetComponent<SinoidScript>() != null)
            {
                other.gameObject.GetComponent<SinoidScript>().health -= 0.07f;
                Destroy(Instantiate(effect, other.gameObject.transform.position, Quaternion.Euler(0, 0, 0), null), 1);
            }
            if (other.gameObject.GetComponent<Pursu3rScript>() != null)
            {
                other.gameObject.GetComponent<Pursu3rScript>().health -= 0.07f;
                Destroy(Instantiate(effect, other.gameObject.transform.position, Quaternion.Euler(0, 0, 0), null), 1);
            }
        }
    }
}
