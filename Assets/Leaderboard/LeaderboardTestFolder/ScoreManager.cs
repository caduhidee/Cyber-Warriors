using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Schepens.UtilScripts;
using System.IO;
using System.Collections.Generic;

using Unity.VisualScripting;
using JetBrains.Annotations;

public class ScoreManager : MonoBehaviour
{
    public HighScoreHandler highScoreHandler;

    public string path;
    
    public TextAsset file;
    
    string msg;

    public int i = 0;

    public List<TextMeshProUGUI> highScores;

    private void Start()
    {
        highScoreHandler = new HighScoreHandler();
        highScoreHandler.ReadFromFile();

        foreach (HighScore hs in highScoreHandler.scores)
        {
            msg = hs.initials + " " + hs.score;
            Debug.Log(msg);
            highScores[i].text = hs.score.ToString();
            i++;
        }
    }
}
