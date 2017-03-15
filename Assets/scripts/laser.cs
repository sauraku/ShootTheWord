using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

    //to check if our letter got touched by laser before being shot
	void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "letter")
        {
            //Debug.Log("gameover" + col.name);
			Camera.main.transform.GetComponent<canvasManagement>().showLose(); // if so.. show the gameover screen
        }
		//Destroy(col.collider.gameObject);
    }
}
