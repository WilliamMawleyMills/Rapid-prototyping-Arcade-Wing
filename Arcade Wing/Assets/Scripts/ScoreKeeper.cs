using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    public Text scoreText;


	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = score.ToString();

    }

    public void ScoreIncrement(int tally)
    {
        score += tally;
    }
}
