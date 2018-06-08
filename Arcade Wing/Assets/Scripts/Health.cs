using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health = 100;
    public GameObject self;
    public GameObject player;
    public GameObject score;
    public GameObject explosionPrefab;
    public GameObject gameOverText;
    public bool enemy = true;

    private void Start()
    {
      
    }

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
