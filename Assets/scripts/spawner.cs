using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawner : MonoBehaviour {

	// Use this for initialization
	public Transform[] letters;
	public Transform sp1,sp2,sp3;
	public float interval=1.0f;
	public Text[] text;
	public Text numberOfTimesPlayed;
	private fileReader file;
	void Awake()
	{
	    Debug.Log(PlayerPrefs.GetInt("color"));
	}
	void Start () {
		file = new fileReader();
		StartCoroutine(spawn());
	}
	
	void Update()
	{
		 if (Input.GetMouseButtonDown (0)) {    
			 Debug.Log("here");
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			 RaycastHit hit;
             if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                 Debug.Log(hit.collider.name);
                 hit.collider.transform.GetComponent<clickAnimation>().split();
             }    
         }
	}

	IEnumerator spawn()
    {
		string word = file.getRandomWord();
		int letterExceptValidOne;
		numberOfTimesPlayed.text= PlayerPrefs.GetInt("played").ToString();
		Transform x;
		for(int i=0;i<word.Length;i++)
		{
			text[i].text=char.ToUpper(word[i]).ToString();
		}
		//Debug.Log(word);
        for(int i=0;i<word.Length;i++)
        {
			//Debug.Log(i+" "+word[i]+" "+interval);
            yield return new WaitForSeconds(interval);
			//Debug.Log(5);
			int temp = char.ToUpper(word[i])-65;
			//Debug.Log(6);
			int turn = Random.Range(0,3);
			//Debug.Log("start");
			if(turn==0)
			{
				//Debug.Log(0);
				x= Instantiate(letters[temp],sp1.position,Quaternion.identity) as Transform;
				x.gameObject.tag="letter";
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
			else if(turn==1)
			{
				//Debug.Log(1);
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
			else
			{
				//Debug.Log(2);
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
		//Debug.Log("end");
		yield return new WaitForSeconds(3f);
		Camera.main.transform.GetComponent<canvasManagement>().showWin();
    }
}
