using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1 : MonoBehaviour {

    public TextMesh questionDisplay1;
    public TextMesh questionDisplay2;
    public TextMesh answerDisplay;
    private int variableA;
    private int variableB;
    private string sign;
    private double answer;
    List<string> signs = new List<string>(new string[] {"+", "-", "*", "/" });

	// Use this for initialization
	void Start () {


        nextQuestion();
		
	}
	
    
	// Update is called once per frame
	void Update () {
		
	}

    public void checkGame(int checkedSign) {

        if (checkedSign == 1)
        {

            nextQuestion();
            

        }
        else {

            questionDisplay1.text = "error";    
        
        }
    }

    public void nextQuestion(){
    
    
        variableA = UnityEngine.Random.Range(0, 10);
        variableB = UnityEngine.Random.Range(0, 10);
        sign = signs[UnityEngine.Random.Range(0, 4)];

        
        questionDisplay1.text = variableA.ToString();
        questionDisplay2.text = variableB.ToString();



        switch (sign)
        {
            case "+":
                answer = variableA + variableB;
                break;
            case "-":
                answer = variableA - variableB;
                break;
            case "/":
                answer = variableA / variableB;
                break;
            case "*":
                answer = variableA * variableB;
                break;

               
        }

        answerDisplay.text = answer.ToString();
    
    }
    
    
}
