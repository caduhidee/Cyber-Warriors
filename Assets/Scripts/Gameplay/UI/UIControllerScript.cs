using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
using Schepens.UtilScripts;

public class UIControllerScript : MonoBehaviour
{

    HighScoreHandler highScoreHandler;  

    public int score;


    public TextMeshProUGUI HPText;
    public TextMeshProUGUI scoreText;

    public GameObject Player;



    void Start()
    {
        highScoreHandler = new HighScoreHandler();
        highScoreHandler.ReadFromFile();
        Player = GameObject.FindWithTag("Player");

    }

    void Update()
    {
        if (Player == null)
        {
            HPText.text = "GAME OVER";
           
            SceneManager.LoadScene("EndScene");

            recordHighScore(score);
        }



        else
        {
            HPText.text = "HP:" + Player.GetComponent<Player>().health.ToString();
        }

        scoreText.text = "Score:" + score.ToString();
    }


    public void recordHighScore(int scoreVal)
    {
        string name = "blah";
        
        highScoreHandler.AddScore(name, scoreVal);
        highScoreHandler.WriteToFile();

        Debug.Log("DkDkdkdkd");
    }
}
