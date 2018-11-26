﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour{

    public float bombRadius = 10f;          // Radius within which enemies are killed.
    public float bombForce = 100f;          // Force that enemies are thrown from the blast.
    public AudioClip fuse;                  // Audioclip of fuse.
    public float fuseTime = 1.5f;
    public GameObject explosion;            // Prefab of explosion effect.

    public void DetonateFused(PlayerStats playerStats) {
        StartCoroutine(FusedCoroutine( playerStats));
    }

    private  IEnumerator FusedCoroutine(PlayerStats playerStats) {
   
        // Play the fuse audioclip.
        AudioSource.PlayClipAtPoint(fuse, transform.position);

        // Wait for 2 seconds.
        yield return new WaitForSeconds(fuseTime);
        Detonate(playerStats);
    }

    public void Detonate(PlayerStats playerStats) {
    
        playerStats.bombsLaid--;

        InflictDamage(playerStats);

        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);

        // Destroy the bomb.
        Destroy(gameObject);
    }

    void InflictDamage(PlayerStats playerStats)
    {
        //TODO

        // Find all the colliders on the Enemies layer within the bombRadius.
        //   Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Enemies"));

        //// For each collider...
        //foreach (Collider2D en in enemies)
        //{
        //    // Check if it has a rigidbody (since there is only one per enemy, on the parent).
        //    Rigidbody2D rb = en.GetComponent<Rigidbody2D>();
        //    if (rb != null && rb.tag == "Enemy")
        //    {
        //        // Find the Enemy script and set the enemy's health to zero.
        //        rb.gameObject.GetComponent<Enemy>().HP = 0;

        //        // Find a vector from the bomb to the enemy.
        //        Vector3 deltaPos = rb.transform.position - transform.position;

        //        // Apply a force in this direction with a magnitude of bombForce.
        //        Vector3 force = deltaPos.normalized * bombForce;
        //        rb.AddForce(force);
        //    }
        //}
    }

}
