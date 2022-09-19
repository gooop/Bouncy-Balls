using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockSpawning : MonoBehaviour
{
    // Called when the ball hits the bottom of the screen
    public static void NextLevel(Tilemap tilemap, TileBase[] tileBases, int levelCount)
    {
        int blocksPlaced = 0;
        if (tilemap != null)
        {
            if (levelCount == 1) 
            {
                while (blocksPlaced == 0)
                {

                    // Iterate over the first row
                    for (int i = -4; i < 2; i++)
                    {
                        if (blocksPlaced > 5)
                        {
                            return;
                        }
                        int placeInt = Random.Range(1, 11);
                        if (placeInt >= 3)
                        {
                            // Set the tiles on the first row to be block tiles
                            tilemap.SetTile(new Vector3Int(i, 3, 0), tileBases[0]);
                            blocksPlaced++;
                        }
                    }
                }
                return;
            }
            
            
            // Blocks start (top left) at (-4, 3) and go to (bottom right) (2, -4)
            for (int i = -4; i <= 2; i++)
            {
                for (int j = -4; j <= 3; j++)
                {
                    Debug.Log("Hello.");
                    tilemap.SetTile(new Vector3Int(i, j, 0), null);
                }

            }
        }
        else
        {
            Debug.Log("[BlockSpawning] Couldn't find tilemap.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
