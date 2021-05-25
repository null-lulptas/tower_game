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

    public bool IsEmpty { get; set; }

    private Tower myTower;
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
        else if(!EventSystem.current.IsPointerOverGameObject() 
            && Master.Instance.Button == null
            && Input.GetMouseButtonDown(0))
        { 
            if(myTower != null)
            {
                Master.Instance.SelectTower(myTower);
            }
            else
            {
                Master.Instance.DeselectTower();
            }
        }
    }

    private void PlaceTower()
    {
        if (PlayerStats.money < 3) return;
        GameObject tower = (GameObject)Instantiate(Master.Instance.Button.TowerPrefab, transform.position, Quaternion.identity);

        tower.transform.SetParent(transform);
        this.myTower = tower.transform.GetComponent<Tower>();
        Master.Instance.TowerBuy();
        PlayerStats.money = PlayerStats.money - 3;
    }
}
