using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour {

    public Health playerHealth;
    public Text healthText;


	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = playerHealth.health.ToString() + "/100";
	}
}
