using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour{

    public bool bombLaid = false;       // Whether or not a bomb has currently been laid.
    public int bombCount = 5;         // How many bombs the player has.
    public AudioClip throwBombClip;     // Sound for when the player lays a bomb.
    public GameObject bombObject;       // Prefab of the bomb.


        //TODO work on the UI
        //private GUITexture bombHUD;         // Heads up display of whether the player has a bomb or not.

        private PlayerControl playerControlScript;

    void Awake(){

            // Setting up the reference.
            //  bombHUD = GameObject.Find("ui_bombHUD").GetComponent<GUITexture>();

        if (GameObject.FindGameObjectWithTag("Player")){

            playerControlScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        }
    }

    void Update(){

        // If the bomb laying button is pressed, the bomb hasn't been laid and there's a bomb to lay...
        if (Input.GetButtonDown("Fire1") && !bombLaid && bombCount > 0){

            // Decrement the number of bombs.
            bombCount--;

            // Set bombLaid to true.
            bombLaid = true;

            // Play the bomb laying sound.
            AudioSource.PlayClipAtPoint(throwBombClip, transform.position);

                // Instantiate the bomb prefab.
                int xOffset = playerControlScript.facingRight ? 1 : -1;
            Vector3 bombSpawnPosition = new Vector3(transform.position.x+ xOffset, transform.position.y, transform.position.z);
            Instantiate(bombObject, bombSpawnPosition, transform.rotation);
        }

        // The bomb heads up display should be enabled if the player has bombs, other it should be disabled.
        //  bombHUD.enabled = bombCount > 0;
    } 
}
