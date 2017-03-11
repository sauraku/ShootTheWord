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
	void Update () {
		
	}

	IEnumerator spawn()
    {
		string word = file.getRandomWord();
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
				Instantiate(letters[temp],sp1.position,Quaternion.identity);
				Instantiate(letters[Random.Range(0,26)],sp2.position,Quaternion.identity);
				Instantiate(letters[Random.Range(0,26)],sp3.position,Quaternion.identity);
			}
			else if(turn==1)
			{
				Instantiate(letters[temp],sp2.position,Quaternion.identity);
				Instantiate(letters[Random.Range(0,26)],sp1.position,Quaternion.identity);
				Instantiate(letters[Random.Range(0,26)],sp3.position,Quaternion.identity);
			}
			else
			{
				Instantiate(letters[temp],sp3.position,Quaternion.identity);
				Instantiate(letters[Random.Range(0,26)],sp1.position,Quaternion.identity);
				Instantiate(letters[Random.Range(0,26)],sp2.position,Quaternion.identity);
			}
            
        }
    }
}
