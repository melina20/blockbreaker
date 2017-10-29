﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null; 

	void Awake() {

		if (instance != null){
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		}else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject); // (gameObject) is the Music Player. Is the instance of the Music Player.
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
