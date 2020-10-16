using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab; 

    public float fireRate = 3;

    private IEnumerator coroutine;

   
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            coroutine = FireRateCoroutine(fireRate);
            StartCoroutine(coroutine);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            //StopAllCoroutines();
            StopCoroutine(coroutine);
        }
    }

    IEnumerator FireRateCoroutine(float rate)
    {
        while (true)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = this.transform.rotation;
            Debug.Log("run");
            yield return new WaitForSeconds(1 / rate);
        }
    }
}
