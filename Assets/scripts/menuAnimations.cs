using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class menuAnimations : MonoBehaviour {

	// Use this for initialization

    public Sprite[] playSprites;
    private int color;
    public Button playButton;
	
    void Awake()
    {
        if (PlayerPrefs.HasKey("color") == false)
        {
            PlayerPrefs.SetInt("color", 0);
        }
    }

	void Start () {
        color =1;
		StartCoroutine(changePlay());
	}
	

    public void onClickPlay()
    {
        PlayerPrefs.SetInt("color", color);
        SceneManager.LoadScene(1);
    }



	IEnumerator changePlay()
    {
        int i = 0;
        while(true)
        {
            yield return new WaitForSeconds(1);
            playButton.GetComponent<Image>().sprite = playSprites[i];
            color= i;
            i++;
            if(i>=playSprites.Length)
            {
                i = 0;
            }
        }
    }
}
