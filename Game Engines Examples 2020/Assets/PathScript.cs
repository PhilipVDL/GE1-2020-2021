using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public int size;
    public float radius;
    public Vector3[] paths;

    private void Start()
    {
        paths = new Vector3[size];
        float theta = Mathf.PI * 2.0f / (float)size;
        for (int i = 0; i < size; i++)
        {
            paths[i] = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
        }
    }
}