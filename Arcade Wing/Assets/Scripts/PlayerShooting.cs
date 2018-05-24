using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float launchForce = 10f;
    public Transform spawnPointOne;
    public Transform spawnPointTwo;
    public GameObject laserPrefab;
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown (KeyCode.Space))
        {
            GameObject laser1 = Instantiate(laserPrefab, spawnPointOne.position, this.transform.rotation) as GameObject;
            laser1.GetComponent<Rigidbody>().AddForce(spawnPointOne.transform.forward * launchForce, ForceMode.Impulse);
            GameObject laser2 = Instantiate(laserPrefab, spawnPointTwo.position, this.transform.rotation) as GameObject;
            laser2.GetComponent<Rigidbody>().AddForce(spawnPointTwo.transform.forward * launchForce, ForceMode.Impulse);
        }
	}
}
