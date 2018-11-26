using UnityEngine;

public class SpecificPlayerStats : MonoBehaviour {

    [Range(0, 10)]
    public int maxHealthPoints;
    public int healthPoints;
    public int bombsLaid;
    [Range(1, 5)]
    public int bombLimit = 1;
    [Range(3, 15)]
    public int maxSpeed = 3;
    [Range(3, 10)]
    public int jumpForce = 3;
    public int jumpCount;
    public bool doubleJumpEnabled;

}