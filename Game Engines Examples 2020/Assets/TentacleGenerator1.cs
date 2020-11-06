using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleGenerator1 : MonoBehaviour {
    public int numSegments;
    public GameObject headPrefab;
    public GameObject segmentPrefab;


    // Use this for initialization
    void Awake () {
        for (int i = 0; i < numSegments; i++)
        {
            Vector3 pos = -i * Vector3.forward * 1.1f; //creates a vector, scaling with i
            GameObject prefab = (i == 0) ? headPrefab : segmentPrefab; //chooses which prefab to use
            GameObject segment = GameObject.Instantiate<GameObject>(prefab); //instantiates the chosen prefab

            segment.transform.position = (transform.rotation * pos) + transform.position; //moves the new segment into place
            //segment.transform.position = // transform.TransformPoint(pos);
            segment.transform.rotation = transform.rotation; //matches new segments rotation to this one
            segment.transform.parent = this.transform; //sets this segment as new segments parent
            segment.GetComponent<Renderer>().material.color =
                Color.HSVToRGB(i / (float)numSegments, 1, 1); //set color of new segment, based on number of segments
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
