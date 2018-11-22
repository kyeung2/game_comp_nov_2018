using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour{

    public AudioClip throwBombClip;     // Sound for when the player lays a bomb.
    public GameObject bombObject;       // Prefab of the bomb.

    private PlayerControl playerControl;
    private PlayerStats playerStats;

    void Awake(){

        playerControl = GetComponent<PlayerControl>();
        playerStats = GetComponent<PlayerStats>();
    }

    void Update(){


        if (Input.GetButtonDown("Fire1") && playerStats.bombsLaid < playerStats.bombLimit) {

            playerStats.bombsLaid++;

            AudioSource.PlayClipAtPoint(throwBombClip, transform.position);

                
            int xOffset = playerControl.facingRight ? 1 : -1;
            Vector3 bombSpawnPosition = new Vector3(transform.position.x+ xOffset, transform.position.y, transform.position.z);

            Instantiate(bombObject, bombSpawnPosition, transform.rotation);
        }


    } 
}
