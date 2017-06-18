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
    float timeLeft = 30;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            timeLeft -= Time.deltaTime;
            timeLabel.GetComponentInChildren<TextMesh>().text = "Czas:" + String.Format("{0:0.0}", timeLeft);
            if (timeLeft < 0)
            {
                DatabaseConnector dbconn = new DatabaseConnector();
                dbconn.saveScore(DeceptiveArrow.player ,DeceptiveArrow.points, "DeceptiveArrow");
                ChangeScene changeScene = new ChangeScene();
                changeScene.ChangeSceneTo(2);
            }
        }
    }
}
