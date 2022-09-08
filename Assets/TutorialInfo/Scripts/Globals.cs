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



public class Globals : MonoBehaviour
{
    public static GameState gameState;
    public static float gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
