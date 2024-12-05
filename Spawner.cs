using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;

    [Range(0f, 2f)]
    public float spawnRange;

    public float spawnTimer = 1;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            Spawn();
            spawnTimer = spawnRange;
        }
    }

    void Spawn()
    {
        var prefab = prefabs[Random.Range(0, prefabs.Length)];
        var place = Vector3.down * 15 + Vector3.right * Random.Range(-5, 5);
        var speed = Vector3.up * 20 + Vector3.right * Random.Range(-3, 3);
        var fruit = Instantiate(prefab, place, Random.rotation);

        fruit.GetComponent<Rigidbody>().velocity = speed;
        Destroy(fruit, 5);
    }
}
