using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "letter")
        {
            Debug.Log("gameover" + col.collider.name);
			Camera.main.transform.GetComponent<canvasManagement>().showLose();
        }
		Destroy(col.collider.gameObject);
    }
}
