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
    List<TextMesh> displays = new List<TextMesh>();
    static List<TextMesh> pairs = new List<TextMesh>();




    // Use this for initialization
    void Start()
    {

        displaySings();



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void displaySings()
    {

        displays.Add(Display1);
        displays.Add(Display2);
        displays.Add(Display3);
        displays.Add(Display4);
        displays.Add(Display5);
        displays.Add(Display6);
        displays.Add(Display7);
        displays.Add(Display8);

        List<string> signs = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" };

        int randDisp;
        int randSign = UnityEngine.Random.Range(0, 8);
        sign = signs[randSign];


        for (int i = 1; i <= 2; i++)
        {

            randDisp = UnityEngine.Random.Range(0, 8 - i);
            Debug.Log("randSign = " + randSign);
            Debug.Log("randDisp = " + randDisp);





            display = displays[randDisp];
            display.text = sign;

            pairs.Add(display);

            displays.RemoveAt(randDisp);
        }

        signs.RemoveAt(randSign);


        for (int i = 1; i <= 6; i++)
        {

            randSign = UnityEngine.Random.Range(0, 8 - i);
            randDisp = UnityEngine.Random.Range(0, 7 - i);

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
                pairs.RemoveAt(i);
            }

        }
        if (pairs.Count == 0)
        {
            Debug.Log("para");
            displaySings();
        }
    }

}
