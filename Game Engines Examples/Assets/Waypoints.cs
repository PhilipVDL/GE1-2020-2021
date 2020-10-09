using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public float radius;
    public int points;
    public float speed;

    public GameObject[] waypoints;
    public GameObject tank;

    public Vector3 target;
    public int targetNum;

    private static StringBuilder message = new StringBuilder();

    private void Start()
    {
        waypoints = new GameObject[points];
        float theta = Mathf.PI * 2.0f / (float)points;
        for (int i = 0; i < waypoints.Length; i++)
        {
            /*
            GameObject sp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            sp.transform.position = transform.TransformPoint(pos);
            */

            GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            point.transform.position = transform.TransformPoint(pos);
            waypoints[i] = point;
        }
        targetNum = 0;
        target = waypoints[targetNum].transform.position;
    }

    private void Update()
    {
        Face();
        Move();
        Check();
    }

    void Face()
    {
        gameObject.transform.LookAt(target);
    }

    void Move()
    {
        float dist = Vector3.Distance(transform.position, target);
        if(dist > 0.1f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            if(targetNum >= waypoints.Length - 1)
            {
                targetNum = -1;
            }
            else
            {
                targetNum++;
                target = waypoints[targetNum].transform.position;
            }
        }
    }

    void Check()
    {
        Vector3 toTank = tank.transform.position - transform.position;
        toTank.Normalize();
        float dot = Vector3.Dot(transform.forward, toTank);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (dot >= 0)
        {
            message.Append("In front");
            if(angle <= 45)
            {
                message.Append("\nWithin 45 degrees cone");
            }
            else
            {
                message.Append("\nNot within 45 degrees cone");
            }
        }
        else
        {
            message.Append("behind");
            message.Append("\nNot within 45 degrees cone");
        }
    }

    public void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + message);
        if (Event.current.type == EventType.Repaint)
        {
            message.Length = 0;
        }
    }
}
