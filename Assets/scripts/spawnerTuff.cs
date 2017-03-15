using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawnerTuff : MonoBehaviour {

	// Everything same as spawner class 
	// only difference is with the way i'm spawning them
	// rest everything is same
	public Transform[] letters;
	public Transform sp1,sp2,sp3;
	public float interval=1.0f;
	public Text[] text;
	public Text numberOfTimesPlayed;
	private fileReader file;

	void Start () {
		file = new fileReader();
		StartCoroutine(spawn());
	}
	
	void Update()
	{
		 if (Input.GetMouseButtonDown (0)) {    
			 //Debug.Log("here");
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			 RaycastHit hit;
             if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                 //Debug.Log(hit.collider.name);
                 hit.collider.transform.GetComponent<clickAnimation>().split();
             }    
         }
	}
    
	int letterExceptValidOne;
    IEnumerator spawn1(int temp)			
    {
        letterExceptValidOne= Random.Range(0,26);		// get any letter other than valid one
        while(letterExceptValidOne==temp)
        {
            letterExceptValidOne= Random.Range(0,26);
        }
        yield return new WaitForSeconds(Random.Range(0f,interval));		// wait for Random second between 0 and interval specified
        Instantiate(letters[letterExceptValidOne],sp1.position,Quaternion.identity);		//spawn it
    }

    IEnumerator spawn2(int temp)			//similar to spawn1
    {
        letterExceptValidOne= Random.Range(0,26);
        while(letterExceptValidOne==temp)
        {
            letterExceptValidOne= Random.Range(0,26);
        }
        yield return new WaitForSeconds(Random.Range(0f,interval));
        Instantiate(letters[letterExceptValidOne],sp2.position,Quaternion.identity);
    }

    IEnumerator spawn3(int temp)		//similar to spawn1
    {
        letterExceptValidOne= Random.Range(0,26);
        while(letterExceptValidOne==temp)
        {
            letterExceptValidOne= Random.Range(0,26);
        }
        yield return new WaitForSeconds(Random.Range(0f,interval));
        Instantiate(letters[letterExceptValidOne],sp3.position,Quaternion.identity);
    }
	IEnumerator spawn()		//same as spawnerclass just now any one can spawn randomly
    {
		string word = file.getRandomWord();
		numberOfTimesPlayed.text= PlayerPrefs.GetInt("played").ToString();		//set the number of time the game has been played
		Transform x;
		for(int i=0;i<word.Length;i++)		//set the speeled out word
		{
			text[i].text=char.ToUpper(word[i]).ToString();
		}
        for(int i=0;i<word.Length;i++)
        {
            yield return new WaitForSeconds(interval);		//initial wait
			int temp = char.ToUpper(word[i])-65;
			int turn = Random.Range(0,3);
			if(turn==0)			// if it's 1st spawnwers turn to spawn the valid letter
			{
                StartCoroutine(spawn2(temp));				//ask spawner 2 to spawn random letter after a random wait
                StartCoroutine(spawn3(temp));				//ask spawner 3 to spawn random letter after a random wait
                yield return new WaitForSeconds(Random.Range(0f,interval));	//wait for random time
				x= Instantiate(letters[temp],sp1.position,Quaternion.identity) as Transform;	//spawn the valid letter
				x.gameObject.tag="letter";					// tag it "letter" for laser collider
				
			}
			else if(turn==1)				//similarily if spawner 2 has to spawn valid letter
			{
				StartCoroutine(spawn1(temp));
                StartCoroutine(spawn3(temp));
                yield return new WaitForSeconds(Random.Range(0f,interval));
				x= Instantiate(letters[temp],sp2.position,Quaternion.identity) as Transform;
				x.gameObject.tag="letter";
			}
			else							//similarily if spawner 2 has to spawn valid letter
			{
				StartCoroutine(spawn2(temp));
                StartCoroutine(spawn1(temp));
                yield return new WaitForSeconds(Random.Range(0f,interval));
				x= Instantiate(letters[temp],sp3.position,Quaternion.identity) as Transform;
				x.gameObject.tag="letter";
			}
            
        }
		yield return new WaitForSeconds(3f);				//wait for game to finish
		Camera.main.transform.GetComponent<canvasManagement>().showWin();			//show win screen
    }
}
