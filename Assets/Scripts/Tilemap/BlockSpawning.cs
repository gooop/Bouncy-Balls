using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockSpawning : MonoBehaviour
{
    // Called when the ball hits the bottom of the screen
    public static void NextLevel(Tilemap tilemap, TileBase[] tileBases, int levelCount)
    {
        // Note: Blocks start (top left) at (-4, 3) and go to (bottom right) (2, -4)
        int blocksPlaced = 0;
        bool powerupPlaced = false;

        // Initial row (on game startup)
        if (tilemap != null)
        {
            if (levelCount == 1)
            {
                Debug.Log("[BlockSpawning] Spawning first row of blocks.");
                while (blocksPlaced == 0)
                {
                    // TODO: Make this a function
                    // Iterate over the first row
                    for (int i = -4; i <= 2; i++)
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

            Debug.Log("[BlockSpawning] Spawning row of blocks.");
            // Move rows down
            for (int i = -4; i <= 3; i++)
            {
                for (int j = -4; j <= 2; j++)
                {
                    TileBase tile = tilemap.GetTile(new Vector3Int(j, i + 1, 0));
                    tilemap.SetTile(new Vector3Int(j, i, 0), tile);
                    Debug.Log("Coords:" + i + "," + j);
                }

            }
            // Spawn next row of blocks
            while (blocksPlaced == 0)
            {

                // Iterate over the first row
                for (int i = -4; i <= 2; i++)
                {
                    if (blocksPlaced > 4)
                    {
                        continue;
                    }
                    else
                    {
                        int placeInt = Random.Range(1, 11);
                        if (placeInt >= 3 && placeInt < 10)
                        { 
                            // Set the tiles on the first row to be block tiles
                            tilemap.SetTile(new Vector3Int(i, 3, 0), tileBases[0]);
                            blocksPlaced++;
                        }
                        else if (placeInt == 10)
                        {
                            tilemap.SetTile(new Vector3Int(i, 3, 0), tileBases[2]);
                        }
                    }
                }
            }
            while (!powerupPlaced)
            {
                // Find a place to put the powerup
                for (int i = -4; i <= 2; i++)
                {
                    if (tilemap.GetTile(new Vector3Int(i, 3, 0)) == null)
                    {
                        int placeInt = Random.Range(1, 11);
                        if (placeInt >= 4)
                        {
                            tilemap.SetTile(new Vector3Int(i, 3, 0), tileBases[1]);
                            powerupPlaced = true;
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("[BlockSpawning] Couldn't find tilemap.");
        }
    }

    int placeRow()
    {
        // TODO: The function from the above TODO
        return 0;
    }
}
