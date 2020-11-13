using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowerSpawnerScript : MonoBehaviour
{
    public GameObject follower;
    public PathScript path;

    int spawns;

    private void Start()
    {
        spawns = path.size;
        for(int i = 0; i < spawns; i++)
        {
            GameObject f = Instantiate(follower);
            PathFolowerScript ps = f.GetComponent<PathFolowerScript>();
            ps.pathScript = path;
            ps.currentWaypoint = i;
        }
    }
}