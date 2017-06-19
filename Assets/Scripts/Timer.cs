using Assets.Classes;
using Assets.Classes.Games;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public GameObject timeLabel;
    public GameObject showButton;

    float timeLeft = 5;
    // Use this for initialization
    void Start()
    {
        DeceptiveArrow.points = 0;
        Equations.points = 0;
        MatchIt.points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        {
            string game = timeLabel.tag;
            timeLeft -= Time.deltaTime;
            timeLabel.GetComponentInChildren<TextMesh>().text = "Czas:" + String.Format("{0:0.0}", timeLeft);
            if (timeLeft < 0)
            {
                ChangeScene changeScene = new ChangeScene();
                
                showButton.SetActive(true);
                if (game == "DeceptiveArrow")
                    showButton.GetComponentInChildren<TextMesh>().text = "Twój wynik " + DeceptiveArrow.points;
                else if (game == "Equations")
                    showButton.GetComponentInChildren<TextMesh>().text = "Twój wynik " + Equations.points;
                else if (game == "MatchIt")
                    showButton.GetComponentInChildren<TextMesh>().text = "Twój wynik " + MatchIt.points;
                if (timeLeft < -5) { 
                    changeScene.ChangeSceneTo(3);
                    DatabaseConnector dbconn = new DatabaseConnector();
                    if (game == "DeceptiveArrow")
                        dbconn.saveScore(DeceptiveArrow.player, DeceptiveArrow.points, game);
                    else if (game == "Equations")
                        dbconn.saveScore(Equations.player, Equations.points, game);
                    else if (game == "MatchIt")
                        dbconn.saveScore(MatchIt.player, MatchIt.points, game);
                }
                
            }
        }
    }
}
