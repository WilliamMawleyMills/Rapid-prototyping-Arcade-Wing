using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    //
    public GameObject asteroidPrefab;
    //
    public GameObject self;
    //the minimum distance from the player an enemy can spawn
    public float minimumDistance = 500f;
    //the maximum distance from the player an enemy can spawn
    public float maximumDistance = 1000f;
    //where the enemy will spawn
    private Vector3 spawnLocation;
    //
    public int spawnAmount = 100;

    // Use this for initialization
    void Start ()
    {
        SpawnLoop(spawnAmount);
	}

    //SpawnLoop()
    //called when a new round of enemies is to be spawned
    //
    //Param:
    //  int i - number of times to run the loop, and by extension, how many enemies to spawn by running NewSpawnLocation function.
    //Return:
    //  void
    private void SpawnLoop(int asteroids)
    {
        for (int i = 0; i < asteroids; i++)
        {
            NewSpawnLocation();
        }
    }

    //NewSpawnLocation()
    //called when a new enemy needs to be spawned
    //
    //Return:
    //  void
    private void NewSpawnLocation()
    {
        //creates a random spawn location between maximum distances both positive and negative on every axis
        spawnLocation = new Vector3(Random.Range(-maximumDistance, maximumDistance), Random.Range(-maximumDistance, maximumDistance), Random.Range(-maximumDistance, maximumDistance));
        if (Vector3.Distance(self.transform.position, spawnLocation) < minimumDistance)
        {
            NewSpawnLocation();
        }
        else
        {
            GameObject asteroid = Instantiate(asteroidPrefab, self.transform.position + spawnLocation, Quaternion.identity) as GameObject;
        }
    }
}
