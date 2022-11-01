using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BallMovement : MonoBehaviour
{
    // Public
    public float ballSpeed = 10.0f * Globals.gameSpeed;
    public Vector2 initialVelocity = new Vector2(1.0f, 10.0f);
    public GameObject tilemapGameObject;
    public GameRunner gameRunner;

    // Private
    private Tilemap tilemap;
    private Vector2 pausedVelocity = Vector2.zero;
    private bool reset = true;

    void Start()
    {
        // Set velocity
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity.normalized * ballSpeed;

        // Find Tilemap
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
        else
        {
            Debug.Log("[BallMovement] Couldn't find tilemap.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        BlockHandling blockHandle = tilemapGameObject.GetComponent(typeof(BlockHandling)) as BlockHandling;
        // Tile collision
        Vector3 hitPosition = Vector3.zero;
        if (tilemap != null && tilemapGameObject == collision.gameObject)
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                Debug.Log("[BallMovement] Tile hit.");
                hitPosition.x = hit.point.x - 0.04f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.04f * hit.normal.y;
                
                blockHandle.Hit(tilemap, tilemap.WorldToCell(hitPosition));
            }
        }

        // Bottom wall collision
        foreach (ContactPoint2D hit in collision.contacts)
        {
            if (hit.point.y <= Globals.bottomEdge + 0.04f)
            {
                gameRunner.NextLevel();
                Globals.gameState = GameState.AIMING;
            }
        }
    }

    private void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody2D>();
        
        if (Globals.gameState != GameState.PLAYING && reset) 
        {
            reset = false;
            pausedVelocity = rb.velocity;
            Debug.Log("[BallMovement] pausedVelocity: " + pausedVelocity);
            rb.velocity = new Vector2(0, 0);
        }
        else if (Globals.gameState == GameState.PLAYING && !reset)
        {
            reset = true;
            rb.velocity = pausedVelocity;
        }
    }
}