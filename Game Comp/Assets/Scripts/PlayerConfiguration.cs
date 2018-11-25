using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfiguration  {
    public enum Characters {
        Ninja,
        Zombie,
        Santa,
        Robot
        // TODO: Add extra available characters;
    }
    public Characters characterChoice;// this is to know what character this player selected e.g. ninja, santa, zombie or robot
}
