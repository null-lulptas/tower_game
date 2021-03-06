using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// General struct to set and get a location
/// </summary>
public struct Location
{
    public int X { get; set; }

    public int Y { get; set; }

    public Location(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}
