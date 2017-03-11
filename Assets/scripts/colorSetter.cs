using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int temp = PlayerPrefs.GetInt("color");
		if(temp==0)
		{
			transform.GetComponent<Camera>().backgroundColor= Color.blue;
		}
		else if(temp == 1)
		{
			transform.GetComponent<Camera>().backgroundColor= Color.green;
		}
		else
		{
			transform.GetComponent<Camera>().backgroundColor= Color.red;
		}
	}
	
	
}
