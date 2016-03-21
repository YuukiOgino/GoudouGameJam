using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public int _score = 0;
	[SerializeField] public Text _scoreText;

	public void addScore(int score)
	{
		_score += score;
	}
}
