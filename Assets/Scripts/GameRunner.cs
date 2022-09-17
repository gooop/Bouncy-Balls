using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BlockSpawning.NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Globals.gameState = GameState.PAUSED;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Globals.gameState = GameState.PLAYING;
        }
    }
}
