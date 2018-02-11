﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public int speed;
	public Boundary boundary;
	public Text lifeText;
	public Text scoreText;

	public int lives;
	public int score;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		lives = 3;
		score = 0;
		UpdateText ();
	}

	void UpdateText() {
		scoreText.text = "Score: " + score.ToString ();
		lifeText.text = "Lives: " + lives.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Boundary")
			return;
		if (lives <= 1) {
			Destroy (gameObject);
		}
		lives--;
		Destroy (other.gameObject);
		UpdateText ();
	}
}
