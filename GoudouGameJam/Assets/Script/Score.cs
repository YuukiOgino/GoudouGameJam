using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	int score;
	[SerializeField]
	Text textScore;

	// Use this for initialization
	void Start () {
		score = 0;
		DisplayScore();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddScore(int inc)
	{
		score += inc;
		DisplayScore();
	}

	void DisplayScore()
	{
		textScore.text = "Score:" + score.ToString();
	}
}
