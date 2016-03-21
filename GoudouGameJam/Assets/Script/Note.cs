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
		GetComponent<Rigidbody>().AddForce(dir, ForceMode.VelocityChange);
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += dir;
		// hit to borderline
		if(transform.position.z < border)
		{
			Destroy(gameObject);
		}
	
	}

	void FixUpdate()
	{

	}

	void OnTriggerEnter(Collider col)
	{
		// hit to hand (leapmotion)
		print(col.gameObject.tag);
		if(col.gameObject.tag == "leap_hand")
		{
			HandController hand = col.transform.root.gameObject.GetComponent<HandController>();
			// left:white right:black
			if (hand.isMoveLeft)
			{
				collector.HitNote(this, 0);
				dir += forceLeft;
				GetComponent<Rigidbody>().AddForce(dir, ForceMode.VelocityChange);
			}
			else if (hand.isMoveRight)
			{
				collector.HitNote(this, 1);
				dir += forceRight;
				GetComponent<Rigidbody>().AddForce(dir, ForceMode.VelocityChange);
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
