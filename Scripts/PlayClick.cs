using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayClick : MonoBehaviour {

	void Start()
	{
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("Play Clicked");
		Application.LoadLevel("MainScene");
	}
}
