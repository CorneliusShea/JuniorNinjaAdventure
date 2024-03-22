using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPatrol : FSM_Action
{
    [SerializeField] float patrolSpeed;

    int currentPoint;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    public override void Act()
    {
        FollowPatrolPath();
    }

    private void FollowPatrolPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint.GetPosition(currentPoint), patrolSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, waypoint.GetPosition(currentPoint)) <= 0.1f)
        {
            currentPoint = (currentPoint + 1) % waypoint.Points.Length;
        }
    }
}
