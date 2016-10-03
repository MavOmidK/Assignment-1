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
