using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    //tells laser who made it
    public GameObject shooter;

    //describes how fast the laser will accelerate over time
    public float acceleration = 10f;
    //describes the maximum speed that the laser will move
    public float maximumVelocity = 200f;
    //rigidbody data storage variable
    private Rigidbody self;
    //storage for health get component
    public Health hit;
    //timer until self destruct
    public float timer = 20;

    // Use this for initialization
    void Start ()
    {
        self = this.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        //if the laser isn't yet at maximum speed on any axis of movement  
        if (self.velocity.z < maximumVelocity && self.velocity.x < maximumVelocity && self.velocity.y < maximumVelocity)
        {
            //add acceleration to movement force
            self.AddForce(this.transform.forward * acceleration, ForceMode.Impulse);
        }
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        timer -= 1 * Time.smoothDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit" + other.ToString());
        if (other.gameObject != shooter)
        {
            hit = other.gameObject.GetComponent<Health>();
            if (hit != null)
            {
                hit.health--;
                //Debug.Log(other.ToString() + "Health Lost");
                Destroy(this.gameObject);
            }
        }
    }
}
