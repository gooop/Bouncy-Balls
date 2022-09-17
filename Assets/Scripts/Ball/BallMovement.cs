using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 10.0f;
    public Vector2 initialVelocity = new Vector2(1.0f, 10.0f);
    public GameObject tilemapGameObject;
    private Tilemap tilemap;

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity.normalized * ballSpeed;
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
        Vector3 hitPosition = Vector3.zero;
        if (tilemap != null && tilemapGameObject == collision.gameObject)
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                Debug.Log("[BallMovement] Tile hit.");
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
    }
}