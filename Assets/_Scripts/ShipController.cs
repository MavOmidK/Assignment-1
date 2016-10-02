using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
    // PRIVATE +++++++++++++++++++++++ //
    private Transform _transform;

    // PUBLIC ++++++++++++++++++++++++ //
    public AudioSource meteorCrashSound;
    public AudioSource partPickUpSound;

    // Use this for initialization
    void Start () {
        this._transform = this.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        this._move();
	}

    // Moves the game object across the x-axis following the mouse movement 
    private void _move() {
        this._transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x - 320f, -290f, 290f), -200f);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Part")) {
            this.partPickUpSound.Play();
        }

        if (other.gameObject.CompareTag("Meteor")) {
            this.meteorCrashSound.Play();
        }
    }
}
