using UnityEngine;
using System.Collections;

// リープモーション　テスト
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
		bool isHand = hasHand(other.gameObject.name);

		if (isHand) 
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

	// リープモーションの手を持っているか
	bool hasHand(string name)
	{
		switch (name) 
		{
		case "bone1":
		case "bone2":
		case "bone3":
		case "palm":
			return true;
		default:
			return false;

		}
	}
}
