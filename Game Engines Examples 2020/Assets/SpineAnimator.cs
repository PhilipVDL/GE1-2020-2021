using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimator : MonoBehaviour {
    public List<Vector3> offsets = new List<Vector3>();
    public List<Transform> children = new List<Transform>();
    public float damping = 10.0f;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false; //hides cursor
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform current = transform.GetChild(i); //tracks transform of current object
            if (i > 0)
            {
                Transform prev = transform.GetChild(i - 1); //tracks transform of object just before this object
                Vector3 offset = current.transform.position - prev.transform.position; //calculates distance between the two objects
                offset = Quaternion.Inverse(prev.transform.rotation) * offset; //calculates the inverse of the previous objects rotation, multiplied by the distance between them
                offsets.Add(offset);                //adds it to the list of offsets
            }            
            children.Add(current); //adds current object to list of children
        }
    }

    // Update is called once per frame
    void Update () {
        
        for (int i = 1; i < children.Count; i++)
        {
            Transform prev = children[i - 1];
            Transform current = children[i];
            Vector3 wantedPosition = prev.position + ((prev.rotation * offsets[i-1])); //previous objects position added to it's rotation multiplied by it's offset value
            Quaternion wantedRotation = Quaternion.LookRotation(prev.transform.position - current.position, prev.transform.up); //calulates the rotationn needed to look at the previous object

            Vector3 lerpedPosition = Vector3.Lerp(current.position, wantedPosition, Time.deltaTime * damping); //lerps between current pos and wanted pos, speed affected by damping
            Vector3 clampedOffset = lerpedPosition - prev.position; //calculate distance between segments
            clampedOffset = Vector3.ClampMagnitude(clampedOffset, offsets[i-1].magnitude); //clamp max distance between segments
            current.position = prev.position + clampedOffset; //keep segments within max distance


            current.rotation = Quaternion.Slerp(current.rotation, wantedRotation, Time.deltaTime * damping); //rotates segments appropriately
        }
    }
}
