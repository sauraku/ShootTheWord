using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

	void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "letter")
        {
            Debug.Log("gameover" + col.name);
			Camera.main.transform.GetComponent<canvasManagement>().showLose();
        }
		//Destroy(col.collider.gameObject);
    }
}
