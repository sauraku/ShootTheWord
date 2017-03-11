using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class fileReader {

	private string[] words = new string[62995];
	public fileReader()
	{
		var fileStream = new FileStream(Application.dataPath+"/wordPool/words.txt", FileMode.Open, FileAccess.Read);
		using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
		{
			string line;
			int i=0;
			while ((line = streamReader.ReadLine()) != null)
			{
				words[i++]=line;
			}
		}
		Debug.Log(words.Length);
		
	}

	public string getRandomWord()
	{
		int temp = Random.Range(0,words.Length);
		while(words[temp].Length<4 || words[temp].Length>10)
		{
			temp = Random.Range(0,words.Length);
		}
		return words[temp];
	}

}
