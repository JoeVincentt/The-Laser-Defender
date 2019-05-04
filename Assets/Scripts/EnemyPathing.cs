using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;


    private void Start()
    {
        try
        {
            waypoints = waveConfig.GetWayPoints();
            transform.position = waypoints[waypointIndex].transform.position;
        }
        catch (NullReferenceException) { }

    }
    private void Update()
    {
        try { Move(); }
        catch (NullReferenceException) { }
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;

    }

    private void Move()
    {

        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisGame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisGame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }


    }
}
