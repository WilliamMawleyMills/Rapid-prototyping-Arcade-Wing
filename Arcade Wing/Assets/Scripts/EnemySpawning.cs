using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public int startEnemies = 10;
    public float timer;
    public float timerLength = 100f;
    public float timerAccelerator = 0.1f;
    public float minimumDistance = 100f;
    public float maximumDistance = 150f;
    public GameObject enemyPrefab;
    public Transform player;
    public Vector3 spawnLocation;

    void Start()
    {
        timer = timerLength;
        for (int i = 0; i < startEnemies; i++)
        {
            newSpawnLocation();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        
        if (timer <= 0f)
        {
            newSpawnLocation();
            timer = timerLength;
            timerLength -= timerAccelerator;
        }
        timer -= 1 * Time.smoothDeltaTime;
	}
    private void newSpawnLocation()
    {
        spawnLocation = new Vector3(Random.Range(-maximumDistance, maximumDistance), Random.Range(-maximumDistance, maximumDistance), Random.Range(-maximumDistance, maximumDistance));
        if (Vector3.Distance(player.position, spawnLocation) < minimumDistance)
        {
            newSpawnLocation();
        } else
        {
            GameObject enemy = Instantiate(enemyPrefab, player.position + spawnLocation, Quaternion.identity) as GameObject;
        }
    }
}
