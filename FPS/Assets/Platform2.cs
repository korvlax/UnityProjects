using UnityEngine;
using System.Collections;

public class Platform2 : MonoBehaviour {

	Vector3 initPos;
	// Use this for initialization
	void Start () {
		initPos = transform.localPosition;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p = new Vector3(initPos.x, initPos.y, 5*Mathf.Sin(0.5f * Time.time));
		transform.localPosition = p; 
	
	}
}
