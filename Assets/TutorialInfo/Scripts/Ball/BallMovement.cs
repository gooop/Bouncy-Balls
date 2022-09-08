using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0.75f, 1);
        Move(direction);
    }

    // Handle collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "MainCamera")
        {
            Debug.Log("Ball collided with Main Camera");
            // TODO: Affect movement
        }

        if (collision.GetType() == typeof(TilemapCollider2D))
        {
            Debug.Log("Ball collided with Tile");
            // TODO: Find out which type of tile has been collided with
        }
    }

    // Move
    private void Move(Vector2 direction)
    {
        Globals.gameState = GameState.PLAYING;
        Globals.gameSpeed = 1;
        if (Globals.gameState == GameState.PLAYING)
        {
            float speed = Globals.gameSpeed * ballSpeed * Time.deltaTime;
            transform.Translate(direction.x, direction.y, speed); 
        }
    }
}


