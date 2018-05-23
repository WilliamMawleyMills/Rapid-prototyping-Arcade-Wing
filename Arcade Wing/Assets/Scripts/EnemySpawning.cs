using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public float timer;
    public float timerLength = 100f;
    public float timerAccelerator = 0.1f;
    public GameObject enemyPrefab;
    public Transform player;
    public Vector3 spawnLocation;

    void Start()
    {
        timer = timerLength;
    }

    // Update is called once per frame
    void Update ()
    {
       
        if (timer <= 0f)
        {
            newSpawnLocation();
            GameObject enemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity) as GameObject;
            timer = timerLength;
            timerLength -= timerAccelerator;
        }
        timer--;
	}
    private void newSpawnLocation()
    {
        spawnLocation = new Vector3(Random.Range(-150f, 150f), Random.Range(-150f, 150f), Random.Range(-150f, 150f));
        if (Vector3.Distance(player.position, spawnLocation) < 100f)
        {
            newSpawnLocation();
        }
    }
}
