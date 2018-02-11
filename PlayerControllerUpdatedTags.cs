using System.Collections;
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
	public Text socialText;
    public Text healthText;
	public Text gpaText;

	public int social;
    public int health;
    public int gpa;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
        social = 0;
        health = 0;
        gpa = 0;
		UpdateText ();
	}

	void UpdateText() {
        socialText.text = "Social: " + social.ToString();
        gpaText.text = "GPA: " + score.ToString ();
        healthText.text = "Health: " + lives.ToString();
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

    // Tags:
    // incGPA
    // decGPA
    // incSL
    // decSL
    // incHLT
    // decHLT
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Boundary")
			return;
		if (other.tag == "gpa") {
			gpa++;
		}
		lives--;
		Destroy (other.gameObject);
		UpdateText ();
	}
}
