using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawnerTuff : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update()
	{
		 if (Input.GetMouseButtonDown (0)) {    
			 Debug.Log("here");
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			 RaycastHit hit;
             if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                 // whatever tag you are looking for on your game object
                 Debug.Log(hit.collider.name);
                 hit.collider.transform.GetComponent<clickAnimation>().split();
             }    
         }
	}
    
	int letterExceptValidOne;
    IEnumerator spawn1(int temp)
    {
        letterExceptValidOne= Random.Range(0,26);
        while(letterExceptValidOne==temp)
        {
            letterExceptValidOne= Random.Range(0,26);
        }
        yield return new WaitForSeconds(Random.Range(0f,interval));
        Instantiate(letters[letterExceptValidOne],sp1.position,Quaternion.identity);
    }

    IEnumerator spawn2(int temp)
    {
        letterExceptValidOne= Random.Range(0,26);
        while(letterExceptValidOne==temp)
        {
            letterExceptValidOne= Random.Range(0,26);
        }
        yield return new WaitForSeconds(Random.Range(0f,interval));
        Instantiate(letters[letterExceptValidOne],sp2.position,Quaternion.identity);
    }

    IEnumerator spawn3(int temp)
    {
        letterExceptValidOne= Random.Range(0,26);
        while(letterExceptValidOne==temp)
        {
            letterExceptValidOne= Random.Range(0,26);
        }
        yield return new WaitForSeconds(Random.Range(0f,interval));
        Instantiate(letters[letterExceptValidOne],sp3.position,Quaternion.identity);
    }
	IEnumerator spawn()
    {
		string word = file.getRandomWord();
		numberOfTimesPlayed.text= PlayerPrefs.GetInt("played").ToString();
		Transform x;
		for(int i=0;i<word.Length;i++)
		{
			text[i].text=char.ToUpper(word[i]).ToString();
		}
        for(int i=0;i<word.Length;i++)
        {
            yield return new WaitForSeconds(interval);
			int temp = char.ToUpper(word[i])-65;
			int turn = Random.Range(0,3);
			if(turn==0)
			{
                StartCoroutine(spawn2(temp));
                StartCoroutine(spawn3(temp));
                yield return new WaitForSeconds(Random.Range(0f,interval));
				x= Instantiate(letters[temp],sp1.position,Quaternion.identity) as Transform;
				x.gameObject.tag="letter";
				
			}
			else if(turn==1)
			{
				StartCoroutine(spawn1(temp));
                StartCoroutine(spawn3(temp));
                yield return new WaitForSeconds(Random.Range(0f,interval));
				x= Instantiate(letters[temp],sp2.position,Quaternion.identity) as Transform;
				x.gameObject.tag="letter";
			}
			else
			{
				StartCoroutine(spawn2(temp));
                StartCoroutine(spawn1(temp));
                yield return new WaitForSeconds(Random.Range(0f,interval));
				x= Instantiate(letters[temp],sp3.position,Quaternion.identity) as Transform;
				x.gameObject.tag="letter";
			}
            
        }
		yield return new WaitForSeconds(3f);
		Camera.main.transform.GetComponent<canvasManagement>().showWin();
    }
}
