using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawn : MonoBehaviour
{
    public GameObject tank;
    public float radius;
    public float spawnDelay;
    public int maxSpawns;

    private void OnEnable()
    {
        StartCoroutine(SpawnCoroutine(spawnDelay));
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(-radius, radius), 3, Random.Range(-radius, radius));
        GameObject enemy = Instantiate(tank, pos, Quaternion.identity);
        enemy.transform.SetParent(transform);
    }

    IEnumerator SpawnCoroutine(float delay)
    {
        while (true)
        {
            if(transform.childCount < maxSpawns)
            {
                Spawn();
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
