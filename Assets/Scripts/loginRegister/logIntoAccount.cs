using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class logIntoAccount : MonoBehaviour {

    public Dropdown loginDropdown;
    public InputField passwordInputField;
    public Button logInButton;
    private bool isPasswordOK = false;
	// Use this for initialization
	public void logInListener() { 
        DatabaseConnector dbConnector = new DatabaseConnector();
        string username = loginDropdown.GetComponentInChildren<Text>().text;
        string password = passwordInputField.GetComponentInChildren<Text>().text;
        string passwordInDb = dbConnector.getLoginAndPassword(username);
        if(password == passwordInDb)
        {
            isPasswordOK = true;
        } else
        {
            logInButton.GetComponentInChildren<Text>().text = "Password is wrong, write it again and click";
            logInButton.GetComponentInChildren<Text>().color = Color.red;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (isPasswordOK) {

            
            ChangeScene changeScene = new ChangeScene();
            changeScene.ChangeSceneTo(2);
            
        }
    }
}
