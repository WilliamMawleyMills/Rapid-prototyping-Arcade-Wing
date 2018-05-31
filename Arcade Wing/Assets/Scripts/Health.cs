using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health = 100;
    public GameObject self;
    public GameObject score;
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
            }
            Destroy(self.gameObject);
        }
	}
}
