using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSink : MonoBehaviour
{
    private float radius = 0.5f;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(transform.childCount > 0)
            {
                transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
                transform.GetChild(0).gameObject.AddComponent<Cleanup>();
                transform.DetachChildren();
            }
            Vector3 pos = new Vector3(Random.Range(-radius, radius), transform.position.y, Random.Range(-radius, radius));
            GetComponent<Rigidbody>().AddExplosionForce(15f, pos, 10f);
        }
    }
}