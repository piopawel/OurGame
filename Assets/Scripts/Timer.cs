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

    float timeLeft = 30;
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
            float score= 0;
            timeLeft -= Time.deltaTime;
            timeLabel.GetComponentInChildren<TextMesh>().text = "Czas:" + String.Format("{0:0.0}", timeLeft);
            if (timeLeft < 0)
            {
                ChangeScene changeScene = new ChangeScene();
                
                showButton.SetActive(true);
                if (game == "DeceptiveArrow")
                    score = DeceptiveArrow.points;
                else if (game == "Equations")
                    score = Equations.points;
                else if (game == "MatchIt") 
                    score = MatchIt.points;
                showButton.GetComponentInChildren<TextMesh>().text = "Twój wynik " + score;
                
                if (timeLeft < -5) { 
                    changeScene.ChangeSceneTo(3);
                    newHighscore(game, score);
                    //PlayerPrefs.SetFloat("DAHighscore", DeceptiveArrow.points);

                    //DatabaseConnector dbconn = new DatabaseConnector();
                    //if (game == "DeceptiveArrow")
                    //    dbconn.saveScore(DeceptiveArrow.player, DeceptiveArrow.points, game);
                    //else if (game == "Equations")
                    //    dbconn.saveScore(Equations.player, Equations.points, game);
                    //else if (game == "MatchIt")
                    //    dbconn.saveScore(MatchIt.player, MatchIt.points, game);
                }
                
            }
        }
    }

    private void newHighscore(String game, float score)
    {
        float highscore1 = PlayerPrefs.GetFloat(game + "1");
        float highscore2 = PlayerPrefs.GetFloat(game + "2");
        float highscore3 = PlayerPrefs.GetFloat(game + "3");
        float highscore4 = PlayerPrefs.GetFloat(game + "4");
        float highscore5 = PlayerPrefs.GetFloat(game + "5");
        if(score > highscore1)
        {
            changeScores(game, score, 1);
            changeScores(game, highscore1, 2);
            changeScores(game, highscore2, 3);
            changeScores(game, highscore3, 4);
            changeScores(game, highscore4, 5);
        } else if (score > highscore2)
        {
            changeScores(game, score, 2);
            changeScores(game, highscore2, 3);
            changeScores(game, highscore3, 4);
            changeScores(game, highscore4, 5);
        } else if (score > highscore3)
        {
            changeScores(game, score, 3);
            changeScores(game, highscore3, 4);
            changeScores(game, highscore4, 5);
        } else if (score > highscore4)
        {
            changeScores(game, score, 4);
            changeScores(game, highscore4, 5);
        } else if (score > highscore5)
        {
            changeScores(game, score, 5);
        }
    }

    private void changeScores(String game, float better, int worseIndex)
    {
        PlayerPrefs.SetFloat(game + worseIndex, better);
    }
}
