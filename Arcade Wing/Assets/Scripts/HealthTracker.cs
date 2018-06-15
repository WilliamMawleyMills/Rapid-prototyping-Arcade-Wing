using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour {

    //The health script from the player object
    public Health playerHealth;
    //the UI text box for the health numbers
    public Text healthText;


	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = playerHealth.health.ToString() + "/100";
	}
}
