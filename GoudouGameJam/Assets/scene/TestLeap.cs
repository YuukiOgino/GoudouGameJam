using UnityEngine;
using System.Collections;

public class TestLeap : MonoBehaviour {

	// 物理演算
	Rigidbody rigi;

	// Use this for initialization
	void Start () 
	{
		rigi = gameObject.GetComponent<Rigidbody>();
		rigi.AddForce(new Vector3(30, 0));
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter (Collider other) 
	{

		// ハンドコントローラー取得
		GameObject obj = GameObject.Find("HandController");
		HandController hand = obj.gameObject.GetComponent<HandController>();

		if (hand)
		{
			
			if (hand.isMoveLeft) 
			{
				// 左に動かした場合は左に移動
				rigi.AddForce(new Vector3(-10, 0));
			}
			else if (hand.isMoveRight) 
			{
				// 右に動かした場合は右に移動
				rigi.AddForce(new Vector3(10, 0));
			}
		}
	}
}
