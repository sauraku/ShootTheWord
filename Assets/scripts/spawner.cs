using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawner : MonoBehaviour {

	// class to handle everything related to spawning of letters
	public Transform[] letters;		//get the letters
	public Transform sp1,sp2,sp3;	//spawners
	public float interval=1.0f;		//to define the amount of time between two consecutive spawns
	public Text[] text;		//textField to display the word being spelled out
	public Text numberOfTimesPlayed;	//	text to show number of times the game has been played
	private fileReader file;	// to read and get random words

	void Start () {
		file = new fileReader();
		StartCoroutine(spawn());	// just get started with spawning letters
	}
	
	void Update()	//to get track of what is clicked
	{
		 if (Input.GetMouseButtonDown (0)) {    
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			 RaycastHit hit;
             if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                 hit.collider.transform.GetComponent<clickAnimation>().split(); //if the object is letter , destroy it.
             }    
         }
	}

	IEnumerator spawn()
    {
		string word = file.getRandomWord();										//get random word
		int letterExceptValidOne;												//to store letter other than the one to be shot
		numberOfTimesPlayed.text= PlayerPrefs.GetInt("played").ToString();		//show number of time the game has been played
		Transform x;															// to store valid instantiated letter
		for(int i=0;i<word.Length;i++)											//show the word being spelled out
		{
			text[i].text=char.ToUpper(word[i]).ToString();
		}
        for(int i=0;i<word.Length;i++)											//number of time that letters are going to get spawned
        {
            yield return new WaitForSeconds(interval);							//initial wait
			int temp = char.ToUpper(word[i])-65;								//temp contains the index of letter in alphabet
			int turn = Random.Range(0,3);										// to randomly select spawner for valid letter
			if(turn==0)															// if 1st spawner spawns
			{
				x= Instantiate(letters[temp],sp1.position,Quaternion.identity) as Transform;	//spawn valid letter
				x.gameObject.tag="letter";														//tag it for laser collider
				//spawn random letter other than valid one from other two spawner
				letterExceptValidOne= Random.Range(0,26);
				while(letterExceptValidOne==temp)
				{
					letterExceptValidOne= Random.Range(0,26);
				}
				Instantiate(letters[letterExceptValidOne],sp2.position,Quaternion.identity);
				letterExceptValidOne= Random.Range(0,26);
				while(letterExceptValidOne==temp)
				{
					letterExceptValidOne= Random.Range(0,26);
				}
				Instantiate(letters[letterExceptValidOne],sp3.position,Quaternion.identity);
			}
			else if(turn==1)														//similarily is spawnwer 2 gets selected
			{
				x= Instantiate(letters[temp],sp2.position,Quaternion.identity) as Transform;
				x.gameObject.tag="letter";
				letterExceptValidOne= Random.Range(0,26);
				while(letterExceptValidOne==temp)
				{
					letterExceptValidOne= Random.Range(0,26);
				}
				Instantiate(letters[letterExceptValidOne],sp1.position,Quaternion.identity);
				letterExceptValidOne= Random.Range(0,26);
				while(letterExceptValidOne==temp)
				{
					letterExceptValidOne= Random.Range(0,26);
				}
				Instantiate(letters[letterExceptValidOne],sp3.position,Quaternion.identity);
			}
			else 																	//similarily if spawner 3 gets selected
			{
				x = Instantiate(letters[temp],sp3.position,Quaternion.identity) as Transform;
				x.gameObject.tag="letter";
				letterExceptValidOne= Random.Range(0,26);
				while(letterExceptValidOne==temp)
				{
					letterExceptValidOne= Random.Range(0,26);
				}
				Instantiate(letters[letterExceptValidOne],sp1.position,Quaternion.identity);
				letterExceptValidOne= Random.Range(0,26);
				while(letterExceptValidOne==temp)
				{
					letterExceptValidOne= Random.Range(0,26);
				}
				Instantiate(letters[letterExceptValidOne],sp2.position,Quaternion.identity);
			}
            
        }
		yield return new WaitForSeconds(3f); 					//wait for game to get finished
		Camera.main.transform.GetComponent<canvasManagement>().showWin();	//show win
    }
}
