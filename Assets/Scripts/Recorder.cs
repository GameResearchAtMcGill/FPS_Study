using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recorder : MonoBehaviour 
{
	public List<Vector3> posBeen = new List<Vector3>(); 
	public List<Vector3> lookAt = new List<Vector3>(); 
	// Use this for initialization
	public float timeRecording = 0.5f;
	private float timeStart; 

	void Start () 
	{
		posBeen.Clear();
		lookAt.Clear();
		timeStart = 0; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeStart+=Time.deltaTime;
		if (timeStart> timeRecording)
		{
			posBeen.Add(gameObject.transform.position);
			lookAt.Add(gameObject.transform.forward); 
			timeStart = 0; 
		}
	}
}
