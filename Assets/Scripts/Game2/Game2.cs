using Assets.Classes.Games;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2 : MonoBehaviour
{

    public TextMesh questionDisplay1;
    List<string> signs = new List<string> { "A", "B", "C", "D" };
    static string sign;
    TextMesh display;

    public TextMesh Display1 = new TextMesh();
    public TextMesh Display2 = new TextMesh();
    public TextMesh Display3 = new TextMesh();
    public TextMesh Display4 = new TextMesh();
    public TextMesh Display5 = new TextMesh();
    public TextMesh Display6 = new TextMesh();
    public TextMesh Display7 = new TextMesh();
    public TextMesh Display8 = new TextMesh();
    public TextMesh Display9 = new TextMesh();
    public TextMesh Display10 = new TextMesh();
    public TextMesh Display11 = new TextMesh();
    public TextMesh Display12 = new TextMesh();
    List<TextMesh> displays = new List<TextMesh>();
    static List<TextMesh> pairs = new List<TextMesh>();
    static int levelBasedOnMood = 4;

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

        displaySings();



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

    public void displaySings()
    {

        displays.Clear();

        switch (mood)
        {
            case 1:

                if (levelBasedOnMood > 6)
                    levelBasedOnMood = levelBasedOnMood - 2;

                break;
            case 3:

                if (levelBasedOnMood < 12)
                {
                    levelBasedOnMood = levelBasedOnMood + 2;
                }
                break;
        }

        displays.Add(Display1);
        displays.Add(Display2);
        displays.Add(Display3);
        displays.Add(Display4);
        displays.Add(Display5);
        displays.Add(Display6);
        displays.Add(Display7);
        displays.Add(Display8);
        displays.Add(Display9);
        displays.Add(Display10);
        displays.Add(Display11);
        displays.Add(Display12);

        for (int i = 0; i < 12; i++)
        {


            displays[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < levelBasedOnMood; i++)
        {


            displays[i].gameObject.SetActive(true);

        }


        List<string> signs = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };

        int randDisp;
        int randSign = UnityEngine.Random.Range(0, 12);
        sign = signs[randSign];


        for (int i = 1; i <= 2; i++)
        {

            randDisp = UnityEngine.Random.Range(0, levelBasedOnMood - i);
            Debug.Log("randSign = " + randSign);
            Debug.Log("randDisp = " + randDisp);





            display = displays[randDisp];
            display.text = sign;

            pairs.Add(display);

            displays.RemoveAt(randDisp);
        }

        signs.RemoveAt(randSign);


        for (int i = 1; i < levelBasedOnMood - 1; i++)
        {

            randSign = UnityEngine.Random.Range(0, 12 - i);
            randDisp = UnityEngine.Random.Range(0, levelBasedOnMood - i -1);

            Debug.Log("randSign = " + randSign);
            Debug.Log("randDisp = " + randDisp);


            sign = signs[randSign];
            display = displays[randDisp];

            display.text = sign;

            displays.RemoveAt(randDisp);
            signs.RemoveAt(randSign);

        }

        for (int i = 0; i < 2; i++)
        {
            Debug.Log(pairs[i]);
        }

    }

    public void checkIfMatch(TextMesh checkedDisplay)
    {
        for (int i = 0; i < pairs.Count; i++)
        {
            if (checkedDisplay == pairs[i])
            {
                Debug.Log("z pary" + pairs[i]);
                pairs.RemoveAt(i);
            }

        }

        if (pairs.Count == 0)
        {
            Debug.Log("para");
            MatchIt.points += 1;
            displaySings();
        }
    }

}
