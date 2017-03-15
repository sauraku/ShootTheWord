using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSetter : MonoBehaviour {

	// Just set the color of the scene
	public Color blue;
	public Color red;
	public Color green;
	void Start () {
		int temp = PlayerPrefs.GetInt("color");
		if(temp==0)
		{
			transform.GetComponent<Camera>().backgroundColor= blue;
		}
		else if(temp == 1)
		{
			transform.GetComponent<Camera>().backgroundColor= green;
		}
		else
		{
			transform.GetComponent<Camera>().backgroundColor= red;
		}
	}
	
	
}
