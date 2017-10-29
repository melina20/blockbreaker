using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false; // the game has no started
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position; // distance between ball and paddle
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch
			if (Input.GetMouseButtonDown(0)){
				print ("mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		// Ball does not trigger Sound when Brick is destroyed.
		// Not 100% sure why, possibly because brick isn't there.

		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		AudioSource audio = GetComponent<AudioSource>();

		if (hasStarted){
			audio.Play();
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	} 
}
