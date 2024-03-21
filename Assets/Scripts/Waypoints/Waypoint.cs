using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Vector3[] points;

    public Vector3[] Points => points;
    public Vector3 EntityPosition { get; set; }

    private void Start()
    {
        EntityPosition = transform.position;
    }

    public Vector3 GetPosition(int index)
    {
        return EntityPosition + points[index];
    }

    private void OnDrawGizmos()
    {
        if(transform.hasChanged)
        {
            EntityPosition = transform.position;
        }


    }
}
