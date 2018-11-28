using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour{

    public AudioClip throwBombClip;     // Sound for when the player lays a bomb.
    public GameObject bomb;       // Prefab of the bomb.
    public GameObject characer;
    private PlayerControl playerControl;
    private PlayerStats playerStats;

    void Awake(){

        playerControl = characer.GetComponent<PlayerControl>();
        playerStats = characer.GetComponent<PlayerStats>();
    }

    void Update(){

        if (playerStats.healthPoints>0 && Input.GetButtonDown("Fire1") && playerStats.bombsLaid < playerStats.bombLimit) {

            playerStats.bombsLaid++;

            AudioSource.PlayClipAtPoint(throwBombClip, transform.position);
                
            int xOffset = playerControl.facingRight ? 1 : -1;
            Vector3 bombSpawnPosition = new Vector3(transform.position.x+ xOffset, transform.position.y, transform.position.z);

            GameObject bombInstance = Instantiate(bomb, bombSpawnPosition, transform.rotation);
            Bomb bombScript = bombInstance.GetComponent<Bomb>();
            bombScript.InitBomb(playerStats);
            bombScript.DetonateFused();
        }
    } 


}
