using UnityEngine;
using System;

public class Enemy : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		
		
		//places alla speheres around their parent like a circle
		float angleStep = 2*(float)Math.PI / transform.childCount;
		float angle = 0f;
		foreach(Transform t in transform){
			//t.localScale -= new Vector3(0.9F, 0.9F, 0.9F);
			Vector3 v;
			v.x = transform.position.x + 2f * (float)Math.Cos(angle);
			v.y = 0f;
			v.z = transform.position.y + 2f * (float)Math.Sin(angle);
			t.position = v;
			angle += angleStep;
		}

		//transform.position = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//float speed = 10f * Time.deltaTime;
		transform.Rotate(Vector3.up, Space.Self);
		transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
		
		player = GameObject.Find("ball");
		//transform.position = player.transform.position;
	}
}
