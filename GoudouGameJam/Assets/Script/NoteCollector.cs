using UnityEngine;
using System.Collections;

public class NoteCollector : MonoBehaviour {

	[SerializeField]
	Score score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HitNote(Note note, byte side)
	{
		if (note.Color == side)
		{
			// score up
			score.AddScore(1);
		}
	}
}
