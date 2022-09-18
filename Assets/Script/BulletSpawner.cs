using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float SpawnRateMin = 0.5f; //弥家 积己 林扁
    public float SpawnRateMax = 1f; // 弥措 积己 林扁

    private Transform target;
    private float SpawnRate;
    private float TimeAfterSpawn; 

    void Start()
    {
        TimeAfterSpawn = 0f;

        SpawnRate = Random.Range(SpawnRateMax, SpawnRateMin);

        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        TimeAfterSpawn += Time.deltaTime;

        if (TimeAfterSpawn >= SpawnRate)
        {
            TimeAfterSpawn = 0f;

            GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);

            Bullet.transform.LookAt(target);

            SpawnRate = Random.Range(SpawnRateMin, SpawnRateMax);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.Die();
        }
    }
}
