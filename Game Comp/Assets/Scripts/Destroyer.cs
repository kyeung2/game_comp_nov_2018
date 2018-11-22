﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public bool destroyOnAwake;         // Whether or not this gameobject should destroyed after a delay, on Awake.
    public float awakeDestroyDelay;     // The delay for destroying it on Awake.
    public bool findChild = false;              // Find a child game object and delete it
    public string namedChild;           // Name the child object in Inspector


    void Awake(){

        //TODO many of these options not using right now, taken from a tutorial but potentially useful.
        // If the gameobject should be destroyed on awake,
        if (destroyOnAwake){
            if (findChild){
               
                Destroy(transform.Find(namedChild).gameObject);
            }
            else{

                //TODO it is this path that is currently used, i.e. destroys the "bombExplosion" gameObject
                Destroy(gameObject, awakeDestroyDelay); 
            }
        }
    }

    void DestroyChildGameObject(){

        // Destroy this child gameobject, this can be called from an Animation Event.
        if (transform.Find(namedChild).gameObject != null)
            Destroy(transform.Find(namedChild).gameObject);
    }

    void DisableChildGameObject(){

        // Destroy this child gameobject, this can be called from an Animation Event.
        if (transform.Find(namedChild).gameObject.activeSelf == true)
            transform.Find(namedChild).gameObject.SetActive(false);
    }

    void DestroyGameObject(){

        // Destroy this gameobject, this can be called from an Animation Event.
        Destroy(gameObject);
    }
}