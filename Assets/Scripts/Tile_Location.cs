using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        this.Position = gridPos;
        transform.position = worldPosition;

        Level_Initiator.Instance.everyTilesLocations.Add(gridPos, this);

    }

    private void OnMouseOver()
    {
        if (Master.Instance.Button != null)
        {
            if (Input.GetMouseButtonDown(0))
                PlaceTower();
        }
    }

    private void PlaceTower()
    {
        GameObject tower = (GameObject)Instantiate(Master.Instance.Button.TowerPrefab, transform.position, Quaternion.identity);

        tower.transform.SetParent(transform);

        Master.Instance.TowerBuy();
    }
}
