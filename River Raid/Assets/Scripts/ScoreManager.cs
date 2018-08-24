using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int score;
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();

        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: " + score;
	}

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
    }
}
