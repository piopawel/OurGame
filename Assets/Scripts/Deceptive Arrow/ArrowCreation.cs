using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Classes.Games;

public class ArrowCreation : MonoBehaviour {
    public GameObject blueArrowPrefab;
    public GameObject redArrowPrefab;
    // Use this for initialization
    void Start () {
        DeceptiveArrow deceptiveArrow = new DeceptiveArrow();
        Arrow generatedArrow = deceptiveArrow.generateArrow();
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

        if(generatedArrow.size == Sizes.small)
            arrow.transform.localScale = new Vector3(0.05f, 0.05f, 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
