using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
	[SerializeField] private GameObject _titleScene;
	[SerializeField] private GameObject _creditScene;

	public void showTitleScene()
	{
		_titleScene.SetActive(true);
		_creditScene.SetActive(false);
	}

	public void showCreditScene()
	{
		_titleScene.SetActive(false);
		_creditScene.SetActive(true);
	}

	public void showGameScene()
	{
		
	}
}
