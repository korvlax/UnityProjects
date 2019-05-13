using UnityEngine;
using System.Collections;

public class PlayerPivot : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.position;
		transform.rotation = player.rotation;
		transform.localScale = player.localScale;

	
	}
}
