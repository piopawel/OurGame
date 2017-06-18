using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1 : MonoBehaviour
{

    public TextMesh questionDisplay1;
    public TextMesh questionDisplay2;
    public TextMesh answerDisplay;
    static int variableA;
    static int variableB;
    static string sign;
    static float answer;
    List<string> signs = new List<string>{ "/", "+", "-", "*" };


    // Use this for initialization
    void Start()
    {

        nextQuestion(10);
        Debug.Log("START" + answer + " == " + variableA + " ? " + variableB);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void checkGame(string checkedSign)
    {


        switch (checkedSign)
        {
            case "+":
                Debug.Log(answer + " == " + variableA + " + " + variableB);
                if (answer == variableA + variableB)
                {
                    Debug.Log(answer + " == " + variableA + " + " + variableB);
                    nextQuestion(10);
                };
                break;
            case "-":
                Debug.Log(answer + " == " + variableA + " - " + variableB);
                if (answer == variableA - variableB)
                {
                    Debug.Log(answer + " == " + variableA + " - " + variableB);
                    nextQuestion(10);
                };
                break;
            case "/":
                Debug.Log(answer + " == " + variableA + " / " + variableB);
                if (answer == variableA / variableB)
                {
                    Debug.Log(answer + " == " + variableA + " / " + variableB);
                    nextQuestion(10);
                };
                break;
            case "*":

                Debug.Log(answer + " == " + variableA + " * " + variableB);
                if (answer == variableA * variableB)
                {
                    Debug.Log(answer + " == " + variableA + " * " + variableB);
                    nextQuestion(10);
                };
                break;

            default:
                Debug.Log("błąd ");
                break;

        }


    }

    public void nextQuestion(int level)
    {

        variableA = UnityEngine.Random.Range(0, level);
        Debug.Log("variableA " + variableA);
        sign = signs[UnityEngine.Random.Range(0, 4)];


        switch (sign)
        {
            case "/":
                variableB = UnityEngine.Random.Range(1, level);
                Debug.Log("variableB " + variableB);
                break;

            default:
                variableB = UnityEngine.Random.Range(0, level);
                break;
        }

        switch (sign)
        {
            case "/":
                while (variableA % variableB != 0)
                {
                    variableA = UnityEngine.Random.Range(0, level);
                    Debug.Log("variableA " + variableA);
                }

                break;

        }

        nextQuestionDisplay();
    }

    public void nextQuestionDisplay()
    {

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
