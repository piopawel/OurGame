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
        string game = label0.tag;
        scores = dbconn.loadScores("PIO", game);
        if (scores.Count > 0)
            label0.GetComponentInChildren<TextMesh>().text = "1.  " + scores[0];
        if (scores.Count > 1)
            label1.GetComponentInChildren<TextMesh>().text = "2.  " + scores[1];
        if (scores.Count > 2)
            label2.GetComponentInChildren<TextMesh>().text = "3.  " + scores[2];
        if (scores.Count > 3)
            label3.GetComponentInChildren<TextMesh>().text = "4.  " + scores[3];
        if (scores.Count > 4)
            label4.GetComponentInChildren<TextMesh>().text = "5.  " + scores[4];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
