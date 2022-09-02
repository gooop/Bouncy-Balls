using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Handle collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Debug.Log("Ball collided with Main Camera");
        }
        if (collision.GetType() == typeof(TilemapCollider2D))
        {
            Debug.Log("Ball collided with Tile");
            // TODO: Find out which type of tile has been collided with
        }
    }

}


