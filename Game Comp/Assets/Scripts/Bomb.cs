using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour{

    public float bombRadius = 10f;          // Radius within which enemies are killed.
    public float bombForce = 100f;          // Force that enemies are thrown from the blast.
    public AudioClip fuse;                  // Audioclip of fuse.
    public float fuseTime = 1.5f;
    public GameObject explosion;            // Prefab of explosion effect.
    private bool detonated = false;

    private PlayerStats selfPlayerStats;
    public void InitBomb(PlayerStats selfPlayerStats)
    {
        this.selfPlayerStats =  selfPlayerStats;
    } 

    public void DetonateFused() {
        StartCoroutine(FusedCoroutine());
    }

    private  IEnumerator FusedCoroutine() {
   
        // Play the fuse audioclip.
        AudioSource.PlayClipAtPoint(fuse, transform.position);
        // Wait for 2 seconds.
        yield return new WaitForSeconds(fuseTime);
        Detonate();
    }

    public void Detonate() {

        if (!detonated){

            detonated = true;
            selfPlayerStats.bombsLaid--;

            InflictDamage();

            // Create a quaternion with a random rotation in the z-axis.
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            // Instantiate the explosion where the rocket is with the random rotation.
            Instantiate(explosion, transform.position, randomRotation);

            // Destroy the bomb.
            Destroy(gameObject);
        }
    }

    void InflictDamage() {

        // early deontate other bombs
        Collider2D[] otherBombs = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Forground"));

        foreach (Collider2D otherBomb in otherBombs){

            Rigidbody2D rb = otherBomb.GetComponent<Rigidbody2D>();
            if (rb != null && rb.tag == "Bomb") {

                Bomb otherBombScript = rb.GetComponent<Bomb>();
                if (this != otherBombScript){
                 
                    otherBombScript.Detonate();
                }
            }
        }

        // damage players
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Player"));
        foreach (Collider2D player in players) {

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null && rb.tag == "Player") {

                rb.gameObject.GetComponent<PlayerStats>().healthPoints--;
                // Find a vector from the bomb to the enemy.
                Vector3 deltaPos = rb.transform.position - transform.position;
                // Apply a force in this direction with a magnitude of bombForce.
                Vector3 force = deltaPos.normalized * bombForce * 200;
                rb.AddForce(force);
            }
        }
    }

}
