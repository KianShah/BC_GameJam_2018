using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers; 


public class ballcreatio : MonoBehaviour {
	List<GameObject> balls = new List<GameObject>();
	float interval = 1; 
	float timer;
	public GameObject ball;
	GameObject ball1 = GameObject.Instantiate(gameObject) as GameObject;
	// Use this for initialization 
	void Start () {
		timer = Time.time + interval;

	}
	// Update is called once per frame
	void Update () {
		if (!(balls.Contains (gameObject))) {
			balls.Add (gameObject);	
		}
		foreach(GameObject ball in balls){
			ball.transform.Translate (0.0f, 0.0f, 0.02f);
		}

		if(Time.time >= timer){
			balls.Clear();
			//GameObject ball = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			GameObject ball = ball1;
			ball.transform.position = new Vector3 (-1.0f + Random.value, 0.0f, 3.0f);
			balls.Add (ball);
			timer = Time.time + interval; 
		}
	}
}