using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Classes.Games;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrowCreation : MonoBehaviour {
    public GameObject blueArrowPrefab;
    public GameObject redArrowPrefab;
    //DeceptiveArrow deceptiveArrow;
    private static System.Random random;

    public GameObject wroc;
    // Use this for initialization
    void Start () {
        random = new System.Random();
        //deceptiveArrow = new DeceptiveArrow();
        createArrow();
    }
    
    public void createArrow()
    {
        //Arrow generatedArrow = deceptiveArrow.generateArrow();
        Arrow generatedArrow = generateArrow();
        blueArrowPrefab = Resources.Load("blueArrow") as GameObject;
        redArrowPrefab = Resources.Load("redArrow") as GameObject;
        Quaternion direction;
        GameObject chosenPrefab;

        //Settings for the arrow
        if (generatedArrow.direction == Directions.W)
            direction = Quaternion.Euler(0, 0, 180);
        else if (generatedArrow.direction == Directions.E)
            direction = Quaternion.Euler(0, 0, 0);
        else if (generatedArrow.direction == Directions.N)
            direction = Quaternion.Euler(0, 0, 90);
        else
            direction = Quaternion.Euler(0, 0, 270);

        if (generatedArrow.color == Colors.blue)
            chosenPrefab = blueArrowPrefab;
        else
            chosenPrefab = redArrowPrefab;

        GameObject arrow = Instantiate(chosenPrefab, new Vector3(0, 1.5f, 1), direction);
        arrow.tag = "arrow";

        if (generatedArrow.size == Sizes.small)
            arrow.transform.localScale = new Vector3(0.05f, 0.05f, 1);
    }

    public Arrow generateArrow()
    {
        Colors color;
        Directions direction;
        Sizes size;

        if (DeceptiveArrow.gameMode == 1)
            direction = (Directions)random.Next(0, 2);
        else
            direction = (Directions)random.Next(0, 4);

        if (DeceptiveArrow.arrows.Count == 0)
        {
            size = Sizes.big;
            //color = usedColor = (Colors)random.Next(0, 2);
            color = (Colors)random.Next(0, 2);
        }
        else
        {
            size = Sizes.small;
            if (DeceptiveArrow.arrows[0].color == Colors.red)
                color = Colors.blue;
            else
                color = Colors.red;
        }

        Arrow arrow = new Arrow(color, direction, size);
        DeceptiveArrow.arrows.Add(arrow);
        return arrow;
    }


}
