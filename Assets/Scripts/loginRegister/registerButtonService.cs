using Assets.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class registerButtonService : MonoBehaviour {

    public Button button;
    public InputField inputField;
    public Text panelText;
    private Player newPlayer;
    private bool userIsCreated = false;

    private bool isUsernameInDB(string newUsername)
    {
        DatabaseConnector dbConnector = new DatabaseConnector();
        List<string> usernames = dbConnector.getUsernames();
        bool usernameIsInDB = false;
        foreach(string username in usernames)
        {
            if (username == newUsername)
            {
                usernameIsInDB = true;
                break;
            }
        }
        if (usernameIsInDB)
            return true;
        else
            return false;
    }
    public void registerButtonListener()
    {
        string buttonText = button.GetComponentInChildren<Text>().text;
        //Username, password, year
        string inputFieldText = inputField.GetComponentInChildren<Text>().text;
        switch (buttonText)
        {
            case "Username exists. Choose another one!":
            case "Confirm username":
                {
                    if (!isUsernameInDB(inputFieldText))
                    {
                        newPlayer = new Player(inputFieldText);
                        button.GetComponentInChildren<Text>().text = "Confirm password";
                        button.GetComponentInChildren<Text>().color = Color.black;
                        inputField.GetComponentInChildren<Text>().text = "";
                        panelText.text = "Password:";
                    } else
                    {
                        button.GetComponentInChildren<Text>().text = "Username exists. Choose another one!";
                        button.GetComponentInChildren<Text>().color = Color.red;
                    }
                    break;
                }
            case "Confirm password":
                {
                    newPlayer.setPassword(inputFieldText);
                    button.GetComponentInChildren<Text>().text = "Create user";
                    inputField.GetComponentInChildren<Text>().text = "";
                    panelText.text = "Year of birth";
                    break;
                }
            case "Create user":
                {
                    /*
                    try
                    {
                        int age = Int32.Parse(inputFieldText);
                        newPlayer.setAgeGroup(age);
                        DatabaseConnector dbConnector = new DatabaseConnector();
                        dbConnector.createUser(newPlayer);
                    } catch (Exception e)
                    {
                        
                    }*/
                    int age = Int32.Parse(inputFieldText);
                    newPlayer.setAgeGroup(age);
                    DatabaseConnector dbConnector = new DatabaseConnector();
                    dbConnector.createUser(newPlayer);
                    userIsCreated = true;

                    break;
                }
        }
            
       
            
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (userIsCreated) {
            ChangeScene changeScene = new ChangeScene();
            changeScene.ChangeSceneTo(1);
        }
    }
}
