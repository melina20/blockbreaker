using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){

		Debug.Log("Level load requested for: " + name);
		Brick.breakableCount = 0;
		SceneManager.LoadScene(name);
		//Application.LoadLevel(name);
	}

	public void QuitLevel(){

		Debug.Log("I Want quit!");	
		Application.Quit();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
	}

	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
