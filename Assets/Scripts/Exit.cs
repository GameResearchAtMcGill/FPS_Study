using UnityEngine;
using System.Collections;
using System; 

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player")
		{
//			Debug.Log("ennd");

			GameObject player = GameObject.FindGameObjectWithTag("Player"); 
			Recorder rPlayer = player.GetComponent<Recorder>(); 
			StartCoroutine(UploadMessage(rPlayer));
//			player.GetComponent<>().enabled = false; 

		}
	}
	IEnumerator UploadMessage(Recorder rPlayer)
	{
		//Send a message to the server. 

		//get the data form the player
		string m = ""; 
		m += "Time: " + DateTime.Now.ToString()+"\n";
		m += "Level: "+Application.loadedLevel.ToString()+"\n"; 

		m += "Pos:\n";

		foreach(Vector3 v in rPlayer.posBeen)
		{
			m+= v.ToString() + ","; 
		}
		m += "\nOrientation:\n"; 
		foreach(Vector3 v in rPlayer.lookAt)
		{
			m+= v.ToString() + ","; 
		}
		m+="\n";
		Debug.Log(m); 

		WWWForm form = new WWWForm();
		form.AddField("message",m); 
		
		WWW w = new WWW("http://www.cs.mcgill.ca/~jtremb59/FPS_Study/upload.php", form);
		yield return w;
		
		if (!string.IsNullOrEmpty(w.error)) 
		{
			print(w.error);
		}
		else 
		{
			print("Finished Uploading Data");
		}
		Application.LoadLevel("EndMenu"); 
	}
}
