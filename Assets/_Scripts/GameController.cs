using UnityEngine;
using System.Collections;

// Reference to the UI nameSpace
using UnityEngine.UI;

// Reference to manage my scenes
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // Private ++++++++++++++++++++++++++++++ //
    private int _livesValue;
    private int _scoreValue;

    // Public +++++++++++++++++++++++++++++++ //
    public int LivesValue {
        get {
            return this._livesValue;
        }
        set {
            this._livesValue = value;
            if (this._livesValue <= 0) {
                this._endGame();
            }
            else {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
            
        }
    }

    public int ScoreValue {
        get {
            return this._scoreValue;
        }
        set {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    // Public TESTING +++++++++++++++++++++++ //
    public int meteorNumber = 3;
    public GameObject meteor;

    [Header("UI Objects")]
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    [Header("GameObjects")]
    public GameObject Ship;
    public GameObject Part;

    // Use this for initialization
    void Start () {
        this.ScoreValue = 0;
        this.LivesValue = 5;

        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);

        for (int meteorCount = 0; meteorCount < this.meteorNumber; meteorCount++) {
            Instantiate(meteor);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void _endGame() {
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.LivesLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        this.Ship.SetActive(false);
        this.Part.SetActive(false);
    }

    // PUBLIC METHODS +++++++++++++++++++++= //
    public void RestartButton_Click() {
        SceneManager.LoadScene("Game");
    }

}
