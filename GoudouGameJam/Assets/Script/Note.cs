using UnityEngine;
using System.Collections;

// 鮭ノートclass
public class Note : MonoBehaviour {

	NoteCollector collector;
	byte color;                                             // 0:white 1:black

	[SerializeField]
	Vector3 dir;                                            // 移動方向
	[SerializeField]
	Vector3 forceLeft;
	[SerializeField]
	Vector3 forceRight;
	[SerializeField]
	float border;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += dir;
		// hit to borderline
		if(transform.position.z < border)
		{
			Destroy(gameObject);
		}
	
	}

	void OnTriggerEnter(Collider col)
	{
		// hit to hand (leapmotion)
		if(col.gameObject.tag == "leap_hand")
		{
			HandController hand = col.GetComponent<HandController>();
			// left:white right:black
			if (hand.isMoveLeft)
			{
				collector.HitNote(this, 0);
				dir += forceLeft;
			}
			else if (hand.isMoveRight)
			{
				collector.HitNote(this, 1);
				dir += forceRight;
			}
		}
	}

	public void Initialize(NoteCollector collector, byte color)
	{
		this.collector = collector;
		this.color = color;
	}

	public byte Color { get { return color; } }
}
