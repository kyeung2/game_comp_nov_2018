public class GameConfiguration  {
    public enum GameModes{
        LastStand,
        Zombie,
        Random
    }
    public enum CharacterStatsMode{
        Default,
        CharacterSpecific
    }
    // How many rounds to play
    public int rounds = 10;
    public GameModes gameMode = GameModes.LastStand;


    public CharacterStatsMode characterStatsMode = CharacterStatsMode.CharacterSpecific;
}
