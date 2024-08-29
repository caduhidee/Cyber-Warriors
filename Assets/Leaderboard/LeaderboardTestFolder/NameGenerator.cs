using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerNumber;
    public string[] playerNames = { "striker", "gamer", "slayer", "warrior", "oiu", "warrior", "sleeper", "guap", "woowop", "boobaadoop" };
    void Start()
    {
       playerNumber = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
