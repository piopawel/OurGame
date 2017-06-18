using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2 : MonoBehaviour {

    public TextMesh questionDisplay1;
    List<string> signs = new List<string> { "A", "B", "C", "D" };
    static string sign;

    static public TextMesh Display1;
    static public TextMesh Display2;
    static public TextMesh Display3;
    static public TextMesh Display4;
    static public TextMesh Display5;
    static public TextMesh Display6;
    static public TextMesh Display7;
    static public TextMesh Display8;
    List<TextMesh> displays = new List<TextMesh> { Display1, Display2, Display3, Display4, Display5, Display6, Display7, Display8 };
	// Use this for initialization
	void Start () {

        displaySings();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void displaySings() {

        List<string> signs = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" };

        sign = signs[UnityEngine.Random.Range(0, 8)];
        TextMesh display = displays[UnityEngine.Random.Range(0, 8)];

        display.text = sign;

    
    
    }
}
