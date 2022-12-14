using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameRunner : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tileBases = new TileBase[3];
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[GameRunner] Running initial setup");
        Globals.levelCount = 1;
        BlockHandling.NextLevel(tilemap, tileBases, Globals.levelCount);
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

    public void NextLevel()
    {
        Globals.levelCount++;
        BlockHandling.NextLevel(tilemap, tileBases, Globals.levelCount);
    }
}
