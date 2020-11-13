using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFolowerScript : MonoBehaviour
{
    public PathScript pathScript;
    public int currentWaypoint;

    //seek
    Vector3 target;
    public float maxSpeed;


    private void Update()
    {
        target = pathScript.paths[currentWaypoint];

        Vector3 desiredPos = target - transform.position;
        Vector3 desiredVector = maxSpeed * desiredPos.normalized;
        transform.forward = desiredVector;
        transform.position += desiredVector * Time.deltaTime;

        if(desiredPos.magnitude < 0.1f)
        {
            if(currentWaypoint >= pathScript.paths.Length - 1)
            {
                currentWaypoint = 0;
            }
            else
            {
                currentWaypoint++;
            }
        }
    }
}