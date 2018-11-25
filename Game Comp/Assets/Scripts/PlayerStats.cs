using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    [Range(1, 5)]
    public int healthPoints = 3;
    public int bombsLaid = 0;
    [Range(1, 5)]
    public int bombLimit = 3;
    [Range(5, 15)]
    public int maxSpeed = 10;
    [Range(3, 10)]
    public int jumpForce = 7;
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