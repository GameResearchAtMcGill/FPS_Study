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
		int i = Random.Range(1,4);
		Application.LoadLevel("level"+i.ToString());
	}
}
