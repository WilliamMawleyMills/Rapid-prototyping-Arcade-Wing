using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    //defines player to look at
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

    //how many seconds until the next time enemy can shoot
    public float timer;
    //how long the timer is when it resets
    public float timerLength = 3f;

    // Use this for initialization
    void Start ()
    {
        shooter = this.gameObject;
        selfRigidbody = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(player.transform);
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
            //Synchronise velocity with shooter so that its speed is relative to the shooter
            laser1.GetComponent<Rigidbody>().AddForce(inheritedVelocity, ForceMode.Impulse);
            //add velocity in direction of shooter
            laser1.GetComponent<Rigidbody>().AddForce(shooter.transform.forward * launchForce, ForceMode.Impulse);

            laser1.GetComponent<Laser>().shooter = shooter;

            //create laser at the spawn point facing the same dirrection as the shooter
            GameObject laser2 = Instantiate(laserPrefab, spawnPointTwo.position, this.transform.rotation) as GameObject;
            //Synchronise velocity with shooter so that its speed is relative to the shooter
            laser2.GetComponent<Rigidbody>().AddForce(inheritedVelocity, ForceMode.Impulse);
            //add velocity in direction of shooter
            laser2.GetComponent<Rigidbody>().AddForce(shooter.transform.forward * launchForce, ForceMode.Impulse);

            laser2.GetComponent<Laser>().shooter = shooter;

            fireOn = false;
        } else if (timer <= 0f)
        {
            timerLength = Random.Range(1, 10);
            timer = timerLength;
            fireOn = true;
        }
        timer -= 1 * Time.smoothDeltaTime;
    }
}
