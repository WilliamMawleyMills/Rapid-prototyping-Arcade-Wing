using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //define how fast the player should accelerate forward
    public float forwardSpeed = 5f;
    //define how fast the player should turn
    public float turningSpeed = 0.5f;
    //determine maximum speed
    public float maximumVelocity = 100f;
    //determine what the player is
    public GameObject self;
    //rigidbody data storage
    private Rigidbody playerRigidbody;

    //control scheme data
    public enum controls
    {
        classicInverted,
        normalized,
        simplified
    }
    //player controls choice
    public controls playerSettings;

    //Control key for pitch up
    private KeyCode pitchUp;
    //control key for pitch down
    private KeyCode pitchDown;
    //control key for yaw right
    private KeyCode yawRight;
    //control key for yaw left
    private KeyCode yawLeft;
    //control key for roll right
    private KeyCode rollRight;
    //control key for roll left
    private KeyCode rollLeft;

	// Use this for initialization
	void Start ()
    {
        playerRigidbody = self.GetComponent<Rigidbody>();

        switch (playerSettings)
        {
            case controls.classicInverted:
                pitchUp = KeyCode.S;
                pitchDown = KeyCode.W;
                yawRight = KeyCode.E;
                yawLeft = KeyCode.Q;
                rollLeft = KeyCode.A;
                rollRight = KeyCode.D;
                break;
            case controls.normalized:
                pitchUp = KeyCode.W;
                pitchDown = KeyCode.S;
                yawRight = KeyCode.E;
                yawLeft = KeyCode.Q;
                rollLeft = KeyCode.A;
                rollRight = KeyCode.D;
                break;
            case controls.simplified:
                pitchUp = KeyCode.W;
                pitchDown = KeyCode.S;
                yawRight = KeyCode.D;
                yawLeft = KeyCode.A;
                rollLeft = KeyCode.Q;
                rollRight = KeyCode.E;
                break;
        }
        return;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //if the maximum speed has not been exceeded in on any axis of velocity
        if (playerRigidbody.velocity.z < maximumVelocity && playerRigidbody.velocity.x < maximumVelocity && playerRigidbody.velocity.y < maximumVelocity)
        {
            //add force to player forward
            playerRigidbody.AddForce(self.transform.forward * forwardSpeed, ForceMode.Impulse);
        }

        //if player presses button, they should be pointed downwards
        if (Input.GetKey(pitchDown))
        {
            self.transform.Rotate(Vector3.right * turningSpeed);
        }
        //if player presses button, they should be pointed upwards
        if (Input.GetKey(pitchUp))
        {
            self.transform.Rotate(Vector3.right * -turningSpeed);
        }
        //if player presses button, they should be pointed right
        if (Input.GetKey(yawRight))
        {
            self.transform.Rotate(Vector3.up * turningSpeed);
        }
        //if player presses button, they should be pointed left
        if (Input.GetKey(yawLeft))
        {
            self.transform.Rotate(Vector3.up * -turningSpeed);
        }
        //if player presses button, they should roll to the left
        if (Input.GetKey(rollLeft))
        {
            self.transform.Rotate(Vector3.forward * turningSpeed);
        }
        //if player presses button, they should roll to the right
        if (Input.GetKey(rollRight))
        {
            self.transform.Rotate(Vector3.forward * -turningSpeed);
        }
    }
}
