using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Rigidbody rb;
	float speed = 500f;
	float upMagnitude = 7000f;
	float frictionMagnitude = 50f;
	public Transform camTrans;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		camTrans = GameObject.Find("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 dir = Vector3.Normalize(transform.position - camTrans.position);
		if (Input.GetKey("d")){
			Vector3 rotDir = Quaternion.AngleAxis(90, Vector3.up) * dir;
			rb.AddForce(rotDir * speed);
        }
		if (Input.GetKey("a")){
			Vector3 rotDir = Quaternion.AngleAxis(-90, Vector3.up) * dir;
			rb.AddForce(rotDir * speed);
        }
		if (Input.GetKey("w")){
			rb.AddForce(dir * speed);
        }
		if (Input.GetKey("s")){
			rb.AddForce(-dir * speed);
        }
		if (Input.GetKeyDown("space") && Mathf.Abs(rb.velocity.y) < 0.05f){
			rb.AddForce(Vector3.up * upMagnitude);
		}

		//gravity subtract 9.81
		//friction subtract
		Vector3 friction = -frictionMagnitude * Vector3.Normalize(rb.velocity);
		rb.AddForce(friction);
	}
}
