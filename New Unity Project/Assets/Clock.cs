using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {

	public Transform hoursTransform;
	public Transform minutesTransform;
	public Transform secondsTransform;

	public Transform indTransform;

	//public Transform[] blocks;

	const float degreesPerHour = 30f;
	const float degreesPerMinute = 6f;
	const float degreesPerSecond = 6f;

	// Use this for initialization
	void Start () {

		//blocks = new Transform[12];
		/*
		for(int i = 0 ; i < blocks.Length ; i++){
			blocks[i] = new Transform();
			blocks[i].localScale = new Vector3(0.01f, 0.01f, 0.01f);
			Debug.Log(blocks[i].localScale);
		}
		*/
	}

	void Update () {
		DateTime time = DateTime.Now;
		hoursTransform.localRotation =
			Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);

		float scale = (float)Math.Sin(time.MilliSecond);
		indTransform.localScale = new Vector3(scale, scale, scale);


		/*
		for(int i = 0 ; i < blocks.Length ; i++){
			blocks[i].localScale = new Vector3(0.0, 0.01f, 0.01f);
		}
		*/

	}
}
