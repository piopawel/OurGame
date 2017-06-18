﻿using Assets.Classes;
using Assets.Classes.Games;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public GameObject timeLabel;
    float timeLeft = 30;
    // Use this for initialization
    void Start()
    {

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
                DatabaseConnector dbconn = new DatabaseConnector();
                if(game == "DeceptiveArrow")
                    dbconn.saveScore(DeceptiveArrow.player ,DeceptiveArrow.points, game);
                else if (game == "Equations")
                    dbconn.saveScore(Equations.player, Equations.points, game);
                else if (game == "MatchIt")
                    dbconn.saveScore(MatchIt.player, MatchIt.points, game);

                ChangeScene changeScene = new ChangeScene();
                changeScene.ChangeSceneTo(2);
            }
        }
    }
}
