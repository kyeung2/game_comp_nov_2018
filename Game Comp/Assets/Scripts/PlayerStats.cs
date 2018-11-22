using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int healthPoints = 5;
    public int bombsLaid = 0;          
    public int bombLimit = 3;
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    public int jumpCount = 0;
    public bool doubleJumpEnabled = false;

    //TODO work on the UI
    //private GUITexture bombHUD;         // Heads up display of whether the player has a bomb or not.

    void Awake () {
        //  bombHUD = GameObject.Find("ui_bombHUD").GetComponent<GUITexture>();

    }

    // Update is called once per frame
    void Update() {


        // The bomb heads up display should be enabled if the player has bombs, other it should be disabled.
        //  bombHUD.enabled = bombCount > 0;
    }
}