using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGeneration : MonoBehaviour
{
    public Transform parent;

    public GameObject healthPrefab;
    public float spawnRadius;

    void Start()
    {
        if (HealthController.currentHealth < 100)
        {
            parent = this.transform;
            SpawnHealth();

        }
    }

    void SpawnHealth()
    {
        for (int i = 0; i < GameManager.healthSpawned; i++)
        {
            GameObject healthInstance = Instantiate(healthPrefab, new Vector3(parent.transform.position.x + Random.Range(-12f, 12f), .25f, parent.transform.position.z + Random.Range(-12f, 12f)), Quaternion.identity);
            healthInstance.transform.parent = parent.transform;
            healthInstance.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + Random.Range(0f, 360f), transform.rotation.z);

        }
    }
}
