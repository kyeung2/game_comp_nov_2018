using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int DEFAULT_MAX_HEALTH_POINTS = 5;
    public static int DEFAULT_HEALTH_POINTS = 5;
    public static int DEFAULT_BOMBS_LAID = 0;
    public static int DEFAULT_BOMB_LIMIT = 3;
    public static int DEFAULT_MAX_SPEED = 10;
    public static int DEFAULT_JUMP_FORCE = 5;
    public static int DEFAULT_JUMP_COUNT = 0;
    public static bool DEFAULT_DOUBLE_JUMP_ENABLED = false;

    [Range(0, 10)]
    public int maxHealthPoints = DEFAULT_MAX_HEALTH_POINTS;
    public int healthPoints = DEFAULT_HEALTH_POINTS;
    public int bombsLaid = DEFAULT_BOMBS_LAID;
    [Range(1, 5)]
    public int bombLimit = DEFAULT_BOMB_LIMIT;
    [Range(3, 15)]
    public int maxSpeed = DEFAULT_MAX_SPEED;
    [Range(3, 10)]
    public int jumpForce = DEFAULT_JUMP_FORCE;
    public int jumpCount = DEFAULT_JUMP_COUNT;
    public bool doubleJumpEnabled = DEFAULT_DOUBLE_JUMP_ENABLED;

    public SpecificPlayerStats specific;

    private void Awake()
    {
        ResetStats();
    }

    public void ResetStats(){

        //TODO Vito to supply this
        //GameConfiguration gameConfiguration = new GameConfiguration();
        GameConfiguration.CharacterStatsMode mode = GameConfiguration.CharacterStatsMode.Default;
        if (mode == GameConfiguration.CharacterStatsMode.Default)
        {

            Debug.Log("defaulting the stats");
            ResetDefaults();
        }
        else
        {
            Debug.Log("keeping character specific stats");
            ResetSpecific();
        }
    }

    void ResetDefaults(){
        maxHealthPoints = DEFAULT_MAX_HEALTH_POINTS;
        healthPoints = DEFAULT_HEALTH_POINTS;
        bombsLaid = DEFAULT_BOMBS_LAID;
        bombLimit = DEFAULT_BOMB_LIMIT;
        maxSpeed = DEFAULT_MAX_SPEED;
        jumpForce = DEFAULT_JUMP_FORCE;
        jumpCount = DEFAULT_JUMP_COUNT;
        doubleJumpEnabled = DEFAULT_DOUBLE_JUMP_ENABLED;
    }

    void ResetSpecific(){
        maxHealthPoints = specific.maxHealthPoints;
        healthPoints = specific.healthPoints;
        bombsLaid = specific.bombsLaid;
        bombLimit = specific.bombLimit;
        maxSpeed = specific.maxSpeed;
        jumpForce = specific.jumpForce;
        jumpCount = specific.jumpCount;
        doubleJumpEnabled = specific.doubleJumpEnabled;
    }
}