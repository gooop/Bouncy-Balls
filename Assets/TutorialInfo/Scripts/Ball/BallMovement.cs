// Copyright 2022 Gavin Castaneda

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed;
    public Rigidbody2D rb;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0.75f, 1);
        rb = GetComponent<Rigidbody2D>();
    }

    // Handle collisions
    void OnCollisionEnter2D(Collision2D collision)
    {

        // Handles wall collisions
        if (collision.gameObject.tag == Tags.CAMERA || collision.GetType() == typeof(TilemapCollider2D))
        {
            Debug.Log("[BallMovement] Ball collided with Main Camera");
           

            if (collision.contacts.Length > 1)
            {
                Debug.Log("[BallMovement] Two contacts with Main Camera");
            }
            // Sometimes two collisions occur
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                // Handle x, if sidewall is hit, normal will not be 0
                if (contactPoint.normal.x != 0)
                {
                    direction.x *= -1;
                }

                // Handle y, if top or bottom wall is hit, normal will not be 0
                if (contactPoint.normal.y == -1)
                {
                    direction.y *= -1;
                }

                // Ball has hit bottom, destroy
                if (contactPoint.normal.y == 1)
                {
                    direction.y *= -1;
                    //Destroy(gameObject);
                }
            }
            
        }

        /*if (collision.gameObject)
        {
            Debug.Log("[BallMovement] Ball collided with Tile");
            direction.y = -direction.y;
            Destroy(collision.gameObject);
        }*/
    }

    // Move
    private void Move(Vector2 direction)
    {
        Globals.gameState = GameState.PLAYING;
        Globals.gameSpeed = 1;
        if (Globals.gameState == GameState.PLAYING)
        {
            float speed = Globals.gameSpeed * ballSpeed * Time.deltaTime * 10;
            rb.velocity = direction * speed;
            Debug.Log("direction" + direction);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        Move(direction);
    }

    
}


