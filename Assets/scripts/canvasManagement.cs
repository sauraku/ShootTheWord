using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
to handle canvas inputs from gameRound Scene
 */

public class canvasManagement : MonoBehaviour {

	public Canvas win,lose;

	public void showWin()
	{
		Time.timeScale=0.0f;	// though no game would have been continued to play in background.. still i prefer to stop Time.
		win.enabled=true;
	}

	public void hideWin()
	{
		Time.timeScale=1.0f;	// start Time
		win.enabled=false;
	}

	public void showLose()
	{
		Time.timeScale=0.0f;
		lose.enabled=true;
	}

	public void hideLose()
	{
		Time.timeScale=1.0f;
		lose.enabled=false;
	}

	public void home()
	{
		PlayerPrefs.SetInt("played",PlayerPrefs.GetInt("played")+1); 	// increment number of times the game has been played
		Time.timeScale=1f;
		SceneManager.LoadScene(0);
	}
	public void restart()
	{
		PlayerPrefs.SetInt("played",PlayerPrefs.GetInt("played")+1);	// increment number of times the game has been played
		lose.enabled=false;												// disable both the canvas.. though redundant.
		win.enabled= false;
		Time.timeScale= 1.0f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}
	

}
