using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    //How many enemies are spawned at game start
    public int startEnemies = 100;
    //How many enemies to spawn each round of enemies
    public int roundEnemies = 10;
    //how many seconds until the next enemy is spawned
    public float timer;
    //how long the timer is when it resets
    public float timerLength = 100f;
    //how muc the timerLength shortens by each time the timer resets
    public float timerAccelerator = 0.1f;
    //the minimum distance from the player an enemy can spawn
    public float minimumDistance = 100f;
    //the maximum distance from the player an enemy can spawn
    public float maximumDistance = 150f;
    //the enemy object to be spawned
    public GameObject enemyPrefab;
    //what the player is
    public GameObject player;
    //where the enemy will spawn
    private Vector3 spawnLocation;

    // Use this for initialization
    void Start()
    {
        timer = timerLength;
        SpawnLoop(startEnemies);
    }

    // Update is called once per frame
    void Update ()
    {
        
        if (timer <= 0f)
        {
            SpawnLoop(roundEnemies);
            timer = timerLength;
            if (timerLength > 10.0f)
            {
                timerLength -= timerAccelerator;
            }
        }
        timer -= 1 * Time.smoothDeltaTime;
	}
    
    //SpawnLoop()
    //called when a new round of enemies is to be spawned
    //
    //Param:
    //  int i - number of times to run the loop, and by extension, how many enemies to spawn by running NewSpawnLocation function.
    //Return:
    //  void
    private void SpawnLoop(int enemies)
    {
        for (int i = 0; i < enemies; i++)
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
        if (Vector3.Distance(player.transform.position, spawnLocation) < minimumDistance)
        {
            NewSpawnLocation();
        } else
        {
            GameObject enemy = Instantiate(enemyPrefab, player.transform.position + spawnLocation, Quaternion.identity) as GameObject;
            enemy.GetComponent<EnemyAI>().player = player;
        }
    } 
}
