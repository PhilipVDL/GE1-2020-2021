using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3);
    }
}
