/*
 * File Name: Scroll
 * Author: Omid Khataee
 * Last Modified: 10/3/2016
 * Program Description: Controller for the QUAD object. It's my scrolling background
 */

using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
    private float _speed = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(0, Time.time * _speed);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
