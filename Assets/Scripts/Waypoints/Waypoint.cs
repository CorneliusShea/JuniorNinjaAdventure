using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Vector3[] points;

    public Vector3[] Points => points;
    public Vector3 EntityPosition { get; set; }

    bool gameStarted;

    private void Start()
    {
        EntityPosition = transform.position;
        gameStarted = true;
    }

    public Vector3 GetPosition(int index)
    {
        return EntityPosition + points[index];
    }

    private void OnDrawGizmos()
    {
        if(!gameStarted && transform.hasChanged)
        {
            EntityPosition = transform.position;
        }


    }
}
