using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject leftWall, rightWall;
    public List<GameObject> prefabs;

    public float spawnInterval = 1f;
    
    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];
            float xPosition = Random.Range(leftWall.transform.position.x + leftWall.transform.localScale.x / 2f, rightWall.transform.position.x - rightWall.transform.localScale.x);
            GameObject item = Instantiate(prefab, new Vector3(xPosition, 6f, 0f), Quaternion.identity);
            
            spawnTimer -= spawnInterval;
        }
    }
}
