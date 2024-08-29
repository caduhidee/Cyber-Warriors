using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow_audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.4f;
        audioSource.volume = .8f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
