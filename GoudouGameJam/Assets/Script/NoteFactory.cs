using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 鮭生成class
public class NoteFactory : MonoBehaviour {

	int bpm = 120;
	int maxNote	= 128;                                      // 総ノート数
	int noteNum;
	float time;
	List<GameObject> noteList;
	bool[] beatbox;
	int beat;

	[SerializeField]
	GameObject noteObj;
	[SerializeField]
	GameObject resultObj;
	[SerializeField]
	NoteCollector collector;

	// Use this for initialization
	void Start () {
		noteNum = 0;
		time = 0;
		noteList = new List<GameObject>();
		beatbox = new bool[16];
		beat = 0;
		CreateBeatbox();

	}
	
	// Update is called once per frame
	void Update () {
		if(noteNum < time * bpm * 2 / 60 && noteNum < maxNote)
		{
			if (beatbox[beat])
			{
				CreateNote();
				noteNum++;
			}
			beat++;
			if(beat == 16)
			{
				CreateBeatbox();
				beat = 0;
			}
		}
		if(noteNum == maxNote && noteList.Count == 0)
		{
			resultObj.SetActive(true);
		}
		noteList.RemoveAll(s => s == null);
		time += Time.deltaTime;
	
	}

	void CreateNote()
	{
		GameObject note = (GameObject)Instantiate(noteObj, transform.position, Quaternion.identity);
		note.GetComponent<Note>().Initialize(collector, (byte)Random.Range(0, 2));
		noteList.Add(note);
	}

	// 16拍中8音のリズムパターンを生成する
	void CreateBeatbox()
	{
		int count = 7;
		for(int i = 0; i < 16; i++)
		{
			if((beatbox[i] = Random.Range(0, 16 - i) > count) == false)
			{
				count--;
			}
		}
	}
}
