using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockHandling : MonoBehaviour
{
    public Tilemap tilemap;

    private Dictionary<Vector3Int, float> hpTiles = new Dictionary<Vector3Int, float>();

    public void ChangeHp(Vector3Int gridPosition) 
    {
        // // TODO: decrement HP here
        // if (newValue <= 0) 
        // {

        // }
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
