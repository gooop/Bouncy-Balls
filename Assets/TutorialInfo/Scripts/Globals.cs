using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PAUSED,
    PLAYING,
    AIMING,
    OVER
}



public class Globals
{
    public static GameState gameState;
    public static float gameSpeed;
    public static float ballCount;
}
public class Tags
{
    public const string CAMERA = "MainCamera";
}


