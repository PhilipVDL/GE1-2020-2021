using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RotateOrb : MonoBehaviour
{
    public float rotSpeed;

    private void Update()
    {
        transform.Rotate(0, 1 * rotSpeed * Time.deltaTime, 0);
    }
}
