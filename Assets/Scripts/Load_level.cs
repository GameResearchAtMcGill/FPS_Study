using UnityEngine;
using System.Collections;

public class Load_level : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel("dev1");
	}
}
