using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Classes.Games;

public class PointDisplay : MonoBehaviour
{
    public GameObject pointLabel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointLabel.GetComponentInChildren<TextMesh>().text = "Odp:" + DeceptiveArrow.points;
    }
}
