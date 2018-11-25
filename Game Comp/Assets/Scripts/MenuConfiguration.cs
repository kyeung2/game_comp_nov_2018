using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConfiguration : MonoBehaviour {
    public PlayerConfiguration[] playerConfigs;
    public GameConfiguration[] gameConfiguration;
    public PlayerResults[] playerResults;
	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }
}
