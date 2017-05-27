using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getUsernames : MonoBehaviour {

    public Dropdown dropdown;
	// Use this for initialization
	void Start () {
		addUsernames();
	}
	
	// Update is called once per frame
	private void addUsernames()
    {
        DatabaseConnector dbConnector = new DatabaseConnector();
        List<string> usernames = dbConnector.connect();
        //List<string> usernames = new List<string> { "Pio", "Marta", "InnaOsoba" };
        dropdown.AddOptions(usernames);
    }
}
