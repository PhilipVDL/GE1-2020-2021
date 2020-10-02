using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public GameObject ringObject;
    public int ringsNumber;
    public int elements;
    public float radius;

    private void Start()
    {
        RingGenerator();
    }

    void RingGenerator()
    {
        float gradient = 1f / ringsNumber;
        for(int k = 1; k < ringsNumber; k++)
        {
            float theta = Mathf.PI * 2.0f / (float)(elements * k);
            for (int i = 0; i < elements * k; i++)
            {
                Vector3 pos = new Vector3(Mathf.Sin(theta * i) * (radius * k), Mathf.Cos(theta * i) * (radius * k), 0);
                GameObject dp = Instantiate(ringObject);
                dp.transform.position = transform.TransformPoint(pos);
                Renderer rend = dp.GetComponent<Renderer>();
                Color color = Color.HSVToRGB(k * gradient, 1, 1);
                rend.material.color = color;
            }
        }
    }
}