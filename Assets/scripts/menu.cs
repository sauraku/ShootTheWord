using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class menu : MonoBehaviour {

	// Use this for initialization

    public Toggle difficult;
    public Sprite[] playSprites;
    private int color;
    public Button playButton;
	
    void Awake()
    {
        if (PlayerPrefs.HasKey("color") == false)
        {
            PlayerPrefs.SetInt("color", 0);
        }
        if (PlayerPrefs.HasKey("played") == false)
        {
            PlayerPrefs.SetInt("played", 0);
        }
        if (PlayerPrefs.HasKey("difficult") == false)
        {
            PlayerPrefs.SetInt("difficult", 0);
        }
    }

	void Start () {
        color =2;
        if(PlayerPrefs.GetInt("difficult")==0)
        {
            difficult.isOn= false;
        }
        else
        {
            difficult.isOn= true;
        }
		StartCoroutine(changePlay());
	}
	

    public void onClickPlay()
    {
        PlayerPrefs.SetInt("color", color);
        Debug.Log(difficult.isOn);
        if(difficult.isOn)
        {
            PlayerPrefs.SetInt("difficult",1);
            SceneManager.LoadScene(2);
        }
        else
        {
            PlayerPrefs.SetInt("difficult",0);
            SceneManager.LoadScene(1);
        }
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
