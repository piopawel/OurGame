using Assets.Classes.Games;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotoinControl : MonoBehaviour
{
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
                change = 0;
                mood = 1;
                if (DeceptiveArrow.gameMode > 1)
                    DeceptiveArrow.gameMode--;
            }
            else if (change > 10)
            {
                change = 0;
                mood = 3;
                if (DeceptiveArrow.gameMode < 5)
                    DeceptiveArrow.gameMode++;
            }
            else mood = 2;
        }

    }

    public int checkMood()
    {
        if (change < -10)
        {
            mood = 3;
            if (DeceptiveArrow.gameMode < 5 )
                DeceptiveArrow.gameMode++;
        }
        else if (change > 10)
        {
            mood = 1;
            if(DeceptiveArrow.gameMode>1)
                DeceptiveArrow.gameMode--;

        }
        else mood = 2;

        return mood;
    }


}