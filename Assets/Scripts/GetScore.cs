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
    public GameObject title;


    // Use this for initialization
    void Start () {
        string game = label0.tag;
        //List<string> scores;
        //DatabaseConnector dbconn = new DatabaseConnector();
        //string game = label0.tag;
        //scores = dbconn.loadScores("PIO", game);
        //if (scores.Count > 0)
            label0.GetComponentInChildren<TextMesh>().text = "1.  " + PlayerPrefs.GetFloat(game + "1");
        //if (scores.Count > 1)
        label1.GetComponentInChildren<TextMesh>().text = "2.  " + PlayerPrefs.GetFloat(game + "2");
        //if (scores.Count > 2)
        label2.GetComponentInChildren<TextMesh>().text = "3.  " + PlayerPrefs.GetFloat(game + "3");
        //if (scores.Count > 3)
        label3.GetComponentInChildren<TextMesh>().text = "4.  " + PlayerPrefs.GetFloat(game + "4");
        //if (scores.Count > 4)
        label4.GetComponentInChildren<TextMesh>().text = "5.  " + PlayerPrefs.GetFloat(game + "5");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
