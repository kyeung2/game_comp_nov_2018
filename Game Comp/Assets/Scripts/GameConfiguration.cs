using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration  {
    public enum GameModes
    {
        LastStand,
        Zombie,
        Random
    }
    public enum CharacterStats
    {
        Equals,
        CharacterSpecific
    }
    // How many rounds to play
    public int rounds = 10;
    public GameModes gameMode = GameModes.LastStand;
    public CharacterStats characterStats;
}
