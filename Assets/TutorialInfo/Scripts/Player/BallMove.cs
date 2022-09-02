using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetType() == typeof(EdgeCollider2D))
        {
            Debug.Log("Player collided with Edge Collider (Probably camera)");
        }
        if (collision.GetType() == typeof(TilemapCollider2D))
        {
            Debug.Log("Player collided with Tile");
            // TODO: Find out which type of tile has been collided with
        }
    }
}
