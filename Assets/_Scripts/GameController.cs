using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    // Private ++++++++++++++++++++++++++++++ //

    // Public +++++++++++++++++++++++++++++++ //

    // Public TESTING +++++++++++++++++++++++ //
    public int meteorNumber = 3;
    public GameObject meteor;


    // Use this for initialization
    void Start () {
	    for (int meteorCount = 0; meteorCount < this.meteorNumber; meteorCount++) {
            Instantiate(meteor);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
