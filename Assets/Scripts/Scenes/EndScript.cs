using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndScript : MonoBehaviour
{
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }


        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("TitleScene");
        }

        time += Time.deltaTime;
        if(time > 30)
        {
            SceneManager.LoadScene("TitleScene");
        }

    }

}
