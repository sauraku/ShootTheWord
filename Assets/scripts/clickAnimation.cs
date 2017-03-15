using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickAnimation : MonoBehaviour {
/*
to govern what happens when a letter is shot
 */
	public GameObject splitParticle;

	public void split()
	{
		this.GetComponent<SphereCollider>().enabled= false;		//remove sphere collider as sometimes unity takes time in destroying
		Instantiate(splitParticle,transform.position,Quaternion.identity);	//instantiate split particles (animation)
		Destroy(gameObject);	//finally destroy it


		/*Transform child = transform.GetChild(0);
		child.GetComponent<Rigidbody>().AddForce(new Vector2(4,5),ForceMode.Impulse);  
		child.GetComponent<Rigidbody>().drag = 0;
		this.GetComponent<Rigidbody>().AddForce(new Vector2(-4,5),ForceMode.Impulse);
		this.GetComponent<Rigidbody>().drag = 0;*/
	}

	

}
