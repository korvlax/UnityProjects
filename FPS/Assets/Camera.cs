using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public GameObject player;
	Vector3 offSet;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		//transform.position = player.transform.position - new Vector3(0,0,20f);
		offSet = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Transform target = player.transform;
		

		//weird af, need to rotate aaround ball, but always keep same distance..
		
		/* 
		float rotSpeed = 2f;
		if (Input.GetKey(";")){
			transform.RotateAround(target.position, Vector3.up, -rotSpeed);
        }
		if (Input.GetKey("k")){
			transform.RotateAround(target.position, Vector3.up, rotSpeed);
        }
		if (Input.GetKey("o")){
			transform.RotateAround(target.position, Vector3.left, rotSpeed);
        }
		if (Input.GetKey("l")){
			transform.RotateAround(target.position, Vector3.left, -rotSpeed);
        }
		*/

		/* 
		//My method
		Vector3 diff = 10*Vector3.Normalize(transform.position -  target.position);
		transform.localPosition = target.position + diff;

		transform.LookAt(target);
		*/

		//another method
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

		transform.position = target.transform.position - (rotation * offSet);

		transform.LookAt(target.transform);

	}
}
