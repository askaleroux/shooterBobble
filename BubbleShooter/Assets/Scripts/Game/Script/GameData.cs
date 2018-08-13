using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public class LevelSelectInfo
    {
        public Difficulty LevelDifficulty; 
    }

    public class Result
    {
        int Score;
        int Rank;
        PlayerInfo Info;
    }

    public class PlayerInfo
    {
        string Name;
    }

    public class GameData
    {
        



    }
}