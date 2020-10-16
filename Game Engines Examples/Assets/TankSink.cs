using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSink : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Sink());
    }

    IEnumerator Sink()
    {
        yield return new WaitForSeconds(4);
        GetComponent<Collider>().enabled = false;
        transform.GetChild(0).GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().drag = 1;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
