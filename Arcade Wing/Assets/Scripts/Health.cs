using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    // the object health
    public int health = 100;
    //the game object to be deleted on death
    public GameObject self;
    //the game object holder of the player scripts to be set to inactive on death
    public GameObject player;
    //the holder of the scorekeeper script
    public GameObject score;
    //particle prefab to call just before death
    public GameObject explosionPrefab;
    //game object holding a number of text boxes to be displayed if the object this script is attached to is the player
    public GameObject gameOverText;
    //tells the script whether this is an enemy or not
    public bool enemy = true;


    // Update is called once per frame
    void Update ()
    {
		if (health <= 0)
        {
            if (enemy == true)
            {
                score = GameObject.Find("ScoreKeeper");
                score.GetComponent<ScoreKeeper>().ScoreIncrement(1);
            } else
            {
                gameOverText.SetActive(true);
                player.GetComponent<PlayerShooting>().enabled = false;
                player.GetComponent<Movement>().enabled = false;
            }
            GameObject explosion = Instantiate(explosionPrefab, self.transform.position, Quaternion.identity) as GameObject;
            Destroy(self.gameObject);
        }
	}
}
