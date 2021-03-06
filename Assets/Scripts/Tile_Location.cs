using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// For setting tile's position (grid system)
/// </summary>
public class Tile_Location : MonoBehaviour
{   
    public Location Position { get; private set; }
    /// <summary>
    /// Gets tile's center
    /// </summary>
    public Vector2 tileCenter
    {
        get 
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Location gridPos, Vector3 worldPosition)
    {
        this.Position = Position;
        transform.position = worldPosition;
    }
}
