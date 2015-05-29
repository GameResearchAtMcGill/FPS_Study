using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Quality : MonoBehaviour {

	// Use this for initialization
	public Text text;
	void Start () 
	{
		Text text = gameObject.GetComponent<Text>(); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
	}

	public void IncreaseQuality()
	{
		QualitySettings.IncreaseLevel(); 
	}
	public void DecreaseQuality()
	{
		QualitySettings.DecreaseLevel(); 
	}
}
