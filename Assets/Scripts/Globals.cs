// Copyright 2022 Gavin Castaneda

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
    public static int levelCount;
    public static float gameSpeed;
    public static float ballCount;
    public static float bottomEdge;
    public static Dictionary<Vector3Int, int> tileHp = new Dictionary<Vector3Int, int>();
}
public class Tags
{
    public const string CAMERA = "MainCamera";
}


