using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public string myName;

	// Use this for initialization
	void Start () {
		myName = "Rickard";
		Debug.Log("Im alive and my name is " + myName);

		//Rigidbody rb = GetComponent<Rigidbody>();
		//rb.mass = 0.1f;
		//rb.AddForce(Vector3.left * 2f);
		transform.position = new Vector3(0,0,0);
	
	}
	
	// Update is called once per frame
	void Update () {


	}
}
