using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerShooting : MonoBehaviour
{
    public XboxController controller;

    //describes the launch force to add to velocity
    public float launchForce = 10f;
    //describes where 1st laser will spawn
    public Transform spawnPointOne;
    //describes where second laser will spawn
    public Transform spawnPointTwo;
    //defines what object the laser is so it knows what to spawn
    public GameObject laserPrefab;
    //defines the object firing the laser
    public GameObject shooter;
    //The player's collider
    public GameObject shooterCollider;
    //shooter Rigidbody
    private Rigidbody shooterRigidbody;
    //defines the velocity of the shooter
    private Vector3 inheritedVelocity;

    //can the player fire right now?
    private bool fireOn = true;

    //how many seconds until the next time player can shoot
    private float timer;
    //how long the timer is when it resets
    public float timerLength = 0.3f;

    private void Start()
    {
        shooterRigidbody = shooter.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        //set the inherited velocity to that of the shooter
        inheritedVelocity = shooterRigidbody.velocity;

        //if the player presses the fire button
        //if (Input.GetKeyDown (KeyCode.Space))
        if (XCI.GetButton(XboxButton.RightBumper, controller) && fireOn == true)
        {
            //create laser at the spawn point facing the same dirrection as the shooter
            GameObject laser1 = Instantiate(laserPrefab, spawnPointOne.position, shooter.transform.rotation) as GameObject;

            laser1.GetComponent<Laser>().shooter = shooterCollider;
            //Synchronise velocity with shooter so that its speed is relative to the shooter
            laser1.GetComponent<Rigidbody>().AddForce(inheritedVelocity, ForceMode.Impulse);
            //add velocity in direction of shooter
            laser1.GetComponent<Rigidbody>().AddForce(shooter.transform.forward * launchForce, ForceMode.Impulse);



            //create laser at the spawn point facing the same dirrection as the shooter
            GameObject laser2 = Instantiate(laserPrefab, spawnPointTwo.position, this.transform.rotation) as GameObject;

            laser2.GetComponent<Laser>().shooter = shooterCollider;
            //Synchronise velocity with shooter so that its speed is relative to the shooter
            laser2.GetComponent<Rigidbody>().AddForce(inheritedVelocity, ForceMode.Impulse);
            //add velocity in direction of shooter
            laser2.GetComponent<Rigidbody>().AddForce(shooter.transform.forward * launchForce, ForceMode.Impulse);

            fireOn = false;
        }
        else if (timer <= 0f)
        {
            timer = timerLength;
            fireOn = true;
        }
        timer -= 1 * Time.smoothDeltaTime;

    }
}
