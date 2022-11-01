using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockHandling : MonoBehaviour
{
    // Called below in placeRow
    private static void SetHp(Vector3Int gridPosition, int hp)
    {
        Debug.Log("[BlockHandling] Added tile " + gridPosition + " to the dictionary");
        Globals.tileHp.Add(gridPosition, hp);
    }

    // Called below in NextLevel, moves the dictionary keys down one on the grid for the next level
    private static void moveDictionary(Vector3Int gridPosition)
    {
        if (Globals.tileHp.ContainsKey(gridPosition))
        {
            Vector3Int newGridPosition = new Vector3Int(gridPosition.x, gridPosition.y + 1, gridPosition.z);
            Globals.tileHp.Add(newGridPosition, Globals.tileHp[gridPosition]);
            Globals.tileHp.Remove(gridPosition);
        }
    }

    // Called in BallMovement when ball hits a tile
    public void Hit(Tilemap tilemap, Vector3Int gridPosition) 
    {
        // Block type tiles
        if (Globals.tileHp.ContainsKey(gridPosition))
        {
            Globals.tileHp[gridPosition] -= 1;

            if (Globals.tileHp[gridPosition] == 0)
            {
                tilemap.SetTile(gridPosition, null);
                Globals.tileHp.Remove(gridPosition);
            }
        }
        else
        {
            //TODO: Handle powerups and "coins" here, another TODO: make these types of tiles not rebound the ball.
            tilemap.SetTile(gridPosition, null);
        }
    }

    public static void NextLevel(Tilemap tilemap, TileBase[] tileBases, int levelCount)
    {
        // Note: Blocks start (top left) at (-4, 3) and go to (bottom right) (2, -4)
        int blocksPlaced = 0;
        bool powerupPlaced = false;

        if (tilemap != null)
        {
            if (levelCount == 1)
            {
                Debug.Log("[BlockHandling] Spawning first row of blocks.");
                blocksPlaced = placeRow(blocksPlaced, tilemap, tileBases, levelCount);
                return;
            }

            Debug.Log("[BlockHandling] Spawning row of blocks.");
            // Move rows down
            for (int i = -4; i <= 3; i++)
            {
                for (int j = -4; j <= 2; j++)
                {
                    TileBase tile = tilemap.GetTile(new Vector3Int(j, i + 1, 0));
                    tilemap.SetTile(new Vector3Int(j, i, 0), tile);

                    // Move the tiles in the dictionary
                    moveDictionary(new Vector3Int(j, i + 1, 0));
                }

            }
            blocksPlaced = placeRow(blocksPlaced, tilemap, tileBases, levelCount);
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
            Debug.Log("[BlockHandling] Couldn't find tilemap.");
        }
    }

    private static int placeRow(int blocksPlaced, Tilemap tilemap, TileBase[] tileBases, int levelCount)
    {
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

                        // Set hp of tile
                        SetHp(new Vector3Int(i, 3, 0), levelCount);

                        blocksPlaced++;
                    }
                    else if (placeInt == 10)
                    {
                        tilemap.SetTile(new Vector3Int(i, 3, 0), tileBases[2]);
                    }
                }
            }
        }
        return blocksPlaced;
    }


}
