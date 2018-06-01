using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    //defines player to target
    public GameObject player;
    //movement speed
    public float forwardSpeed = 10;
    //define how fast the player should turn
    public float turningSpeed = 2f;
    //determine maximum speed
    public float maximumVelocity = 100f;
    //variable for rigidbody storage
    public Rigidbody selfRigidbody;
    //can the enemy fire right now?
    private bool fireOn = false;

    //describes the launch force to add to velocity
    public float launchForce = 20f;
    //describes where 1st laser will spawn
    public Transform spawnPointOne;
    //describes where second laser will spawn
    public Transform spawnPointTwo;
    //defines what object the laser is so it knows what to spawn
    public GameObject laserPrefab;
    //defines the object firing the laser
    public GameObject shooter;
    //defines the velocity of the shooter
    private Vector3 inheritedVelocity;

    //what its looking at right now
    private GameObject target;
    //how close they should get to target before they change targets
    public float targetDistance = 30f;

    //how many seconds until the next time enemy can shoot
    public float timer;
    //how long the timer is when it resets
    public float timerLength = 3f;

    // Use this for initialization
    void Start ()
    {
        selfRigidbody = this.GetComponent<Rigidbody>();
        target = player;
    }
	
	// Update is called once per frame
	void Update ()
    {

        transform.LookAt(target.transform);
        if (Vector3.Distance (shooter.transform.position, target.transform.position) < targetDistance)
        {
            NavigationCycle(Random.Range(1, 8));
        }
        //if the maximum speed has not been exceeded in on any axis of velocity
        if (selfRigidbody.velocity.z < maximumVelocity && selfRigidbody.velocity.x < maximumVelocity && selfRigidbody.velocity.y < maximumVelocity)
        {
            //add force to player forward
            selfRigidbody.AddForce(this.transform.forward * forwardSpeed, ForceMode.Impulse);
        }
        ShootCycle();
    }

    //ShootCycle()
    //called by update to run laser routine
    //
    //return:
    //  void
    private void ShootCycle()
    {
        if (fireOn == true)
        {
            //set the inherited velocity to that of the shooter
            inheritedVelocity = selfRigidbody.velocity;

            //create laser at the spawn point facing the same dirrection as the shooter
            GameObject laser1 = Instantiate(laserPrefab, spawnPointOne.position, shooter.transform.rotation) as GameObject;
            laser1.GetComponent<Laser>().shooter = shooter;
            //Synchronise velocity with shooter so that its speed is relative to the shooter
            laser1.GetComponent<Rigidbody>().AddForce(inheritedVelocity, ForceMode.Impulse);
            //add velocity in direction of shooter
            laser1.GetComponent<Rigidbody>().AddForce(shooter.transform.forward * launchForce, ForceMode.Impulse);


            //create laser at the spawn point facing the same dirrection as the shooter
            GameObject laser2 = Instantiate(laserPrefab, spawnPointTwo.position, this.transform.rotation) as GameObject;
            laser2.GetComponent<Laser>().shooter = shooter;
            //Synchronise velocity with shooter so that its speed is relative to the shooter
            laser2.GetComponent<Rigidbody>().AddForce(inheritedVelocity, ForceMode.Impulse);
            //add velocity in direction of shooter
            laser2.GetComponent<Rigidbody>().AddForce(shooter.transform.forward * launchForce, ForceMode.Impulse);

           

            fireOn = false;
        } else if (timer <= 0f && target == player)
        {
            timerLength = Random.Range(0.2f, 3f);
            timer = timerLength;
            fireOn = true;
        }
        timer -= 1 * Time.smoothDeltaTime;
    }

    //Navigation Cycle()
    //called if the enemy is too close to its target in order to find a new target
    //
    //Param:
    //  int rand - a random number to indicate what position to target.
    //Return:
    //  void
    private void NavigationCycle(int rand)
    {
        if (rand == 1)
        {
            target = player;
        }
        if (rand == 2)
        {
            target = GameObject.Find("Nav1");
        }
        if (rand == 3)
        {
            target = GameObject.Find("Nav2");
        }
        if (rand == 4)
        {
            target = GameObject.Find("Nav3");
        }
        if (rand == 5)
        {
            target = GameObject.Find("Nav4");
        }
        if (rand == 6)
        {
            target = GameObject.Find("Nav5");
        }
        if (rand == 7)
        {
            target = GameObject.Find("Nav6");
        }
    }
}
