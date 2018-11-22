using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour{

<<<<<<< Updated upstream
    public bool bombLaid = false;       // Whether or not a bomb has currently been laid.
    public int bombCount = 5;         // How many bombs the player has.
=======
>>>>>>> Stashed changes
    public AudioClip throwBombClip;     // Sound for when the player lays a bomb.
    public GameObject bombObject;       // Prefab of the bomb.

    private PlayerControl playerControl;
    private PlayerStats playerStats;

    void Awake(){

        playerControl = GetComponent<PlayerControl>();
        playerStats = GetComponent<PlayerStats>();
    }

    void Update(){

<<<<<<< Updated upstream
        // If the bomb laying button is pressed, the bomb hasn't been laid and there's a bomb to lay...
        if (Input.GetButtonDown("Fire1")
            //TODO just want to see a few bombs on screen for now.
          // && !bombLaid && bombCount > 0
           ){

            // Decrement the number of bombs.
            bombCount--;

            // Set bombLaid to true.
            bombLaid = true;
=======
        if (Input.GetButtonDown("Fire1") && playerStats.bombsLaid < playerStats.bombLimit) {

            playerStats.bombsLaid++;
>>>>>>> Stashed changes

            AudioSource.PlayClipAtPoint(throwBombClip, transform.position);
<<<<<<< Updated upstream

                // Instantiate the bomb prefab.
                int xOffset = playerControlScript.facingRight ? 1 : -1;
=======
                
            int xOffset = playerControl.facingRight ? 1 : -1;
>>>>>>> Stashed changes
            Vector3 bombSpawnPosition = new Vector3(transform.position.x+ xOffset, transform.position.y, transform.position.z);



            Instantiate(bombObject, bombSpawnPosition, transform.rotation);
        }


    } 
}
