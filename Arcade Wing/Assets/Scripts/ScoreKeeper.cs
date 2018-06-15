using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    //the score
    public int score;
    //the text box the score is shown in
    public Text scoreText;


	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = score.ToString();

    }

    //ScoreIncrement()
    //called from another script when an enemy dies
    //
    //Param:
    //  int tally - the addition to the score for destroying the enemy
    //Return:
    //  void
    public void ScoreIncrement(int tally)
    {
        score += tally;
    }
}
