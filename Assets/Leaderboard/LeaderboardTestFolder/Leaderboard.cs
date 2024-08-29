using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;


[System.Serializable]
public class Leaderboard : MonoBehaviour
{
    public  List<TextMeshProUGUI> names;
    public List<TextMeshProUGUI> scores;
    
    private string publicKey = "7f3f80dd5134494edc5741e6145ce007ea12a4fe0e77240af9caa462f6794faf";
    private void Start()
    {
        GetLeaderboard();

    }

    private void FixedUpdate()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {

        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {
            int looplength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i = 0; i < looplength; i++) 
            {
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    
}
