using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        AddColliderOnCamera();
    }

    public void AddColliderOnCamera()
    {
        if (Camera.main == null)
        {
            Debug.LogError("No camera found. Make sure you have tagged your camera with 'MainCamera'");
            return;
        }

        Camera cam = Camera.main;

        if (!cam.orthographic)
        {
            Debug.LogError("Camera is not set as orthographic");
            return;
        }

        // Get or Add Edge Collider 2D component
        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : gameObject.GetComponent<EdgeCollider2D>();

        // Making camera bounds
        var leftBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var leftTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var rightTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        var rightBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

        var edgePoints = new[] { leftBottom, leftTop, rightTop, rightBottom, leftBottom };
        Globals.bottomEdge = leftBottom.y;

        // Adding edge points
        edgeCollider.points = edgePoints;
        edgeCollider.offset = new Vector2(.5f, 0);
    }

}
