/*
 * File Name: MenuController
 * Author: Omid Khataee
 * Last Modified: 10/3/2016
 * Program Description: Controller for the Menu
 */
 
 using UnityEngine;
using System.Collections;

// reference to Scene Management

using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // PUBLIC METHODS
    public void StartButton_Click() {
        SceneManager.LoadScene("Game");
    }
}
