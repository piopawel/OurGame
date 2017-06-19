using Assets.Classes.Games;
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
    static int levelBasedOnMood = 10;

    static float oldX;
    static float oldY;
    static float oldZ;

    static float sqDiffX;
    static float sqDiffY;
    static float sqDiffZ;

    static float diffX = 0;
    static float diffY = 0;
    static float diffZ = 0;

    double timeLeft = 0.5;
    double sum;
    int change = 0;
    public static int mood = 2;

    // Use this for initialization
    void Start()
    {

        nextQuestion(10);
        Debug.Log("START" + answer + " == " + variableA + " ? " + variableB);
    }


    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            diffX = 10 * (oldX - Input.acceleration.x);
            diffY = 10 * (oldY - Input.acceleration.y);
            diffZ = 10 * (oldZ - Input.acceleration.z);
            sqDiffX = diffX * diffX;
            sqDiffY = diffY * diffY;
            sqDiffZ = diffZ * diffZ;

            sum = sqDiffX + sqDiffY + sqDiffZ;

            if (sum < 4)
            {
                change--;
            }
            else if (sum > 20)
            {
                change++;
            }

            oldX = Input.acceleration.x;
            oldY = Input.acceleration.y;
            oldZ = Input.acceleration.z;
            timeLeft = 0.5;

            if (change < -10)
            {
                mood = 3;
            }
            else if (change > 10)
            {
                mood = 1;
            }

            else mood = 2;
        }

    }


    public void checkGame(string checkedSign)
    {
        switch (mood)
        {
            case 1:

                if (levelBasedOnMood > 8)
                    levelBasedOnMood = levelBasedOnMood - 2;

                break;
            case 3:

                levelBasedOnMood = levelBasedOnMood + 2;

                break;

        }


        switch (checkedSign)
        {
            case "+":
                Debug.Log(answer + " == " + variableA + " + " + variableB);
                if (answer == variableA + variableB)
                {
                    Debug.Log(answer + " == " + variableA + " + " + variableB);
                    Equations.points += 1;
                    nextQuestion(10);
                };
                break;
            case "-":
                Debug.Log(answer + " == " + variableA + " - " + variableB);
                if (answer == variableA - variableB)
                {
                    Debug.Log(answer + " == " + variableA + " - " + variableB);
                    Equations.points += 1;
                    nextQuestion(10);
                };
                break;
            case "/":
                Debug.Log(answer + " == " + variableA + " / " + variableB);
                if (answer == variableA / variableB)
                {
                    Debug.Log(answer + " == " + variableA + " / " + variableB);
                    Equations.points += 1;
                    nextQuestion(10);
                };
                break;
            case "*":

                Debug.Log(answer + " == " + variableA + " * " + variableB);
                if (answer == variableA * variableB)
                {
                    Debug.Log(answer + " == " + variableA + " * " + variableB);
                    Equations.points += 1;
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
        // Rzecz do ustawienia - wg poziomu dać różne punkty (0.9, 1, 1.1)
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
