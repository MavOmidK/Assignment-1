/*
 * File Name: SpaceController
 * Author: Omid Khataee
 * Last Modified: 10/3/2016
 * Program Description: Controller for the BackGround
 * NOT USED
 */

using UnityEngine;
using System.Collections;

public class SpaceController : MonoBehaviour {
    // PRIVATE +++++++++++++++++++++++++ //
    private int _speed;
    private Transform _transform;

    // PUBLIC ++++++++++++++++++++++++++ //
    public int Speed
    {
        get {
            return this._speed;
        }

        set {
            this._speed = value;
        }
    }

	// Use this for initialization
	void Start ()
    {
        this._transform = this.GetComponent<Transform>();
        this._reset();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this._move();
        this._checkBounds();
	}

    //  Moves the game object down the screen by _speed px per frame
    private void _move()
    {        
        Vector2 newPosition = this._transform.position;
        newPosition.y -= Speed;
        this._transform.position = newPosition;
    }

    // Checks to see if the game object meets the top-border of the screen
    private void _checkBounds()
    {
        if (this.transform.position .y <= -560f) {
            this._reset();
        }
    }

    // Resets the game to the original postion
    private void _reset()
    {
        this._speed = 5;
        this.transform.position = new Vector2(0f, 560f);
    }
}
