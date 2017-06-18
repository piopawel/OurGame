using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Classes.Games;

public class EqPointDisplay : MonoBehaviour
{
    public GameObject pointLabel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointLabel.GetComponentInChildren<TextMesh>().text = "Odp:" + Equations.points;
    }
}
