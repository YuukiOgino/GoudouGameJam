using UnityEngine;
using System.Collections;

// 鮭生成class
public class NoteFactory : MonoBehaviour {

	int bpm = 60;
	int maxNote	= 100;                                      // 総ノート数
	int noteNum;
	float time;
	Vector3 spawnPos;

	[SerializeField]
	GameObject noteObj;

	// Use this for initialization
	void Start () {
		noteNum = 0;
		time = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(noteNum < time * bpm / 60)
		{
			CreateNote();
			noteNum++;
		}
		time += Time.deltaTime;
	
	}

	void CreateNote()
	{
		Instantiate(noteObj, spawnPos, Quaternion.identity);
	}
}
