using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class menu : MonoBehaviour {

	// Use this for initialization

/*
class to handle main menu screen
 */
    public Toggle difficult;        //to toggle between easy and difficult mode
    public Sprite[] playSprites;    //sprites to keep the play button animated with red blue and green color
    private int color;      // just a variable to store current color of the play button
    public Button playButton;   // reference to play button
	
    void Awake()
    {
        // to initalize PlayerPrefs that i'm going to use ahead
        if (PlayerPrefs.HasKey("color") == false)   //to track what was the color of button when clicked
        {
            PlayerPrefs.SetInt("color", 0);
        }
        if (PlayerPrefs.HasKey("played") == false)  // to keep count on number of times the game has been played
        {
            PlayerPrefs.SetInt("played", 0);
        }
        if (PlayerPrefs.HasKey("difficult") == false)   // to save the state of toggle fo next time opening of game
        {
            PlayerPrefs.SetInt("difficult", 0);
        }
    }

	void Start () {
        color =2;   // initially let the color be red
        if(PlayerPrefs.GetInt("difficult")==0)      //also restore the state of toggle "difficult"
        {
            difficult.isOn= false;
        }
        else
        {
            difficult.isOn= true;
        }
		StartCoroutine(changePlay());       //start the animation on playButton
	}
	

    public void onClickPlay()
    {
        // save the color and difficulty toggle state before launching the game
        PlayerPrefs.SetInt("color", color);
        //Debug.Log(difficult.isOn);
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



	IEnumerator changePlay()        // animating game button
    {
        int i = 0;
        while(true)
        {
            yield return new WaitForSeconds(1);
            playButton.GetComponent<Image>().sprite = playSprites[i];   // rotate sprite every second
            color= i;
            i++;
            if(i>=playSprites.Length)
            {
                i = 0;
            }
        }
    }
}
