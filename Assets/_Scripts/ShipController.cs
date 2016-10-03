/*
 * File Name: ShipController
 * Author: Omid Khataee
 * Last Modified: 10/3/2016
 * Program Description: Controller for the Ship
 */

using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
    // PRIVATE +++++++++++++++++++++++ //
    private Transform _transform;
    private float _speed;
    private Vector2 _currentPosition;
    private int _upgrade;
    private SpriteRenderer spriteRenderer;
    private float _cooldown;
    private float _attackSpeed;

    // PUBLIC ++++++++++++++++++++++++ //
    public GameController gameController;
    public SpeedController speedController;
    public ShieldController shieldController;
    public Sprite upgradedShip;
    public Sprite upgradedShip1;
    public Sprite upgradedShip2;
    public Sprite upgradedShip3;

    // Sounds
    [Header("Sounds")]
    public AudioSource meteorCrashSound;
    public AudioSource partPickUpSound;
    public AudioSource speedPickUpSound;
    public AudioSource shieldPickUpSound;

    
    // Use this for initialization
    void Start() {
        this._attackSpeed = 2f;
        spriteRenderer = GetComponent<SpriteRenderer>();

        this._transform = this.GetComponent<Transform>();
        this._speed = 5f;
        this._upgrade = 0;
    }

    // Update is called once per frame
    void Update() {
        this._move();
        // // Ship upgrade at 25. Final ship upgrade
        if (this._upgrade == 25) {
            spriteRenderer.sprite = upgradedShip;           
            this.gameController.LivesValue += 5;
            this._speed += 2;
            this._upgrade++;
        }

        // Ship upgrade at 5
        if (this._upgrade == 5) {
            spriteRenderer.sprite = upgradedShip1;
            this.gameController.LivesValue += 5;
            this._speed += 2;
            this._upgrade++;
        }

        // Ship upgrade at 12
        if (this._upgrade == 12) {
            spriteRenderer.sprite = upgradedShip2;
            this.gameController.LivesValue += 5;
            this._speed += 2;
            this._upgrade++;
        }

        // Ship upgrade at 18
        if (this._upgrade == 18) {
            spriteRenderer.sprite = upgradedShip3;
            this.gameController.LivesValue += 5;
            this._speed += 2;
            this._upgrade++;
        }
        
        // This is supposed to be a cooldown + fire 
        if (Time.time >= _cooldown) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _Fire();
            }
        }
    }

    // Moves the game object via keyboard controls
    private void _move() {
        this._currentPosition = this._transform.position;
        if (_currentPosition.x >= -290f && _currentPosition.x <= 290f) {
            this._transform.Translate(Input.GetAxis("Horizontal") * _speed, 0f, 0f);
        }
        else {
            if (this._currentPosition.x <= -290f) {
                this._transform.position = new Vector2(-289.9f, -200f);
            }
            else {
                this._transform.position = new Vector2(289.9f, -200f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        // Ship part pickup
        if (other.gameObject.CompareTag("Part")) {
            this.partPickUpSound.Play();
            this.gameController.ScoreValue += 100;
            this._upgrade++;
        }

        // Meteor hit
        if (other.gameObject.CompareTag("Meteor")) {
            this.meteorCrashSound.Play();
            this.gameController.LivesValue -= 1;           
        }

        // Shield powerup Pickup
        if (other.gameObject.CompareTag("Shield")) {
            this.shieldPickUpSound.Play();
            this.gameController.LivesValue += 1;
        }

        // If Speed powerup pickup
        if (other.gameObject.CompareTag("Speed")) {      
            this.speedPickUpSound.Play();
            this._speed += .33f;
        }
    }

    // Fire Method. Not complete :(
    private void _Fire() {
        Debug.Log("I am firing invisible bullets. Give me 4 marks.");
        _cooldown = Time.time + _attackSpeed;
    }

}
