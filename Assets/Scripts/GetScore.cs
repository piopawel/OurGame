using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {

    public GameObject label0;
    public GameObject label1;
    public GameObject label2;
    public GameObject label3;
    public GameObject label4;


    // Use this for initialization
    void Start () {
        List<string> scores;
        DatabaseConnector dbconn = new DatabaseConnector();
        scores = dbconn.loadScores("PIO", "DeceptiveArrow");
        if (scores.Count > 0)
            label0.GetComponentInChildren<Text>().text = scores[0];
        if (scores.Count > 1)
            label1.GetComponentInChildren<Text>().text = scores[1];
        if (scores.Count > 2)
            label2.GetComponentInChildren<Text>().text = scores[2];
        if (scores.Count > 3)
            label3.GetComponentInChildren<Text>().text = scores[3];
        if (scores.Count > 4)
            label4.GetComponentInChildren<Text>().text = scores[4];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
