using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickAnimation : MonoBehaviour {

	public GameObject splitParticle;

	public void split()
	{
		this.GetComponent<SphereCollider>().enabled= false;
		Instantiate(splitParticle,transform.position,Quaternion.identity);
		Destroy(gameObject);


		/*Transform child = transform.GetChild(0);
		child.GetComponent<Rigidbody>().AddForce(new Vector2(4,5),ForceMode.Impulse);  
		child.GetComponent<Rigidbody>().drag = 0;
		this.GetComponent<Rigidbody>().AddForce(new Vector2(-4,5),ForceMode.Impulse);
		this.GetComponent<Rigidbody>().drag = 0;*/
	}

	

}
