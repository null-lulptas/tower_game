﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int currentwawepointindex = 0;

    private void Start()
    {
        target = waypoints.points[0];

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            GetnextWaypoint();
    }

    void GetnextWaypoint()
    {
        if (currentwawepointindex >= waypoints.points.Length - 1 )
        {
            EndPath();
            return;
        }
        currentwawepointindex++;
        target = waypoints.points[currentwawepointindex];
    }

    void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner.enemeiesAlive--;
        Destroy(gameObject);        
    }
}
