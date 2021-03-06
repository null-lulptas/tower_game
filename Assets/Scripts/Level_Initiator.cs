using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Generates a map from txt, sets each tiles location (grid system)
/// </summary>
public class Level_Initiator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiles;

    //Dictionary of every tiles' locations
    public Dictionary<Location, Tile_Location> everyTilesLocations { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Intialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Main method which generates the map
    /// </summary>
    private void Intialize()
    {
        everyTilesLocations = new Dictionary<Location, Tile_Location>();
        
        string[] map = TxtToLevel();
        //Map's x size
        int mapXsize = map[0].ToCharArray().Length;
        //Map's y size
        int mapYsize = map.Length;

        //Starting point for tile placement (top left cornet)
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < mapYsize; y++)
        {
            char[] tileRow = map[y].ToCharArray();

            for(int x = 0; x < mapXsize; x++)
            {
                Place(tileRow[x],x, y, worldStart);
            }
        }
    }

    /// <summary>
    /// Converts data from level txt to string array
    /// one line of text represnts one line of map
    /// </summary>
    /// <returns>string array of map's horizontal lines</returns>
    private string[] TxtToLevel()
    {
        TextAsset data = Resources.Load("Level1") as TextAsset;

        string tmp = data.text.Replace(Environment.NewLine, string.Empty);

        return tmp.Split('|');
    }

    /// <summary>
    /// Gets tile's size
    /// </summary>
    public int TileSize
    {
        get { return (int)tiles[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    /// <summary>
    /// Places a specific tile to a specific location
    /// </summary>
    /// <param name="type">type of tile</param>
    /// <param name="x">tile's x location</param>
    /// <param name="y">tile's y location</param>
    /// <param name="worldStart">starting point for tile placement</param>
    private void Place(char type, int x, int y, Vector3 worldStart)
    {
        int typeIndex = int.Parse(type.ToString());

        Tile_Location tile = Instantiate(tiles[typeIndex]).GetComponent<Tile_Location>();

        tile.Setup(new Location(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y)));

        everyTilesLocations.Add(new Location(x, y), tile);
    }
}
