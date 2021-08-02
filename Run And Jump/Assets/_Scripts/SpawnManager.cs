using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclesPrefabs;
    private float startSpawn = 2f;
    private float reapeatSpawn = 2f;
    private Vector3 spawnpos;

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        spawnpos = this.transform.position;
        InvokeRepeating("SpawnObstacles", startSpawn, reapeatSpawn );

        _playerController = GameObject.Find("Player")
            .GetComponent<PlayerController>();
    }

    void SpawnObstacles()
    {
        if (!_playerController.GameOver)
        {
            GameObject obstacles = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)];
            Instantiate(obstacles, spawnpos, obstacles.transform.rotation);
        }
       
    }
    
}
