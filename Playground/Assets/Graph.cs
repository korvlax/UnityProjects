using UnityEngine;
using System.Collections;

public class Graph : MonoBehaviour {
	public Transform pointPrefab;
	//[Range(10,100)]
	//public int resolution = 20;

	[Range(10,100)]
	public int width = 20;

	[Range(10,100)]
	public int height = 20;

	Transform[,] points;

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		/* 
		float step = 2f /  resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position;
		position.y = 0f;
		position.z = 0f;

		points = new Transform[resolution];
		for(int i = 0 ; i < resolution ; i++){
			Transform point = Instantiate(pointPrefab);
			position.x = (i + 0.5f) * step - 1f;// x [-1, 1]
			//position.y = position.x * position.x * position.x;
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform, false);

			points[i] = point;
		}
		*/

		float side = 1f / width;
		Vector3 scale = Vector3.one * side;
		Vector3 position;
		position.y = 0f;
		points = new Transform[height,width];
		for(int i = 0 ; i < height ; i++){
			for(int j = 0 ; j < width ; j++){
				Transform point = Instantiate(pointPrefab);
				position.x = side*j;
				position.z = side*i;
				point.localPosition = position;
				point.localScale = scale;
				point.SetParent(transform, false);

				points[i,j] = point;
			}
		}


	}
	
	// Update is called once per frame
	void Update () {	
		/*
		for(int i = 0 ; i  < points.Length ; i++){
			Transform point = points[i];
			Vector3 position = point.position;
			position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
			position.z = Mathf.Sin(Mathf.PI * (position.y + Time.time));
			point.localPosition = position;
			

		}
		*/
		for(int i = 0 ; i < height ; i++){
			for(int j = 0 ; j < width ; j++){
				Transform point = points[i,j];
				Vector3 position = point.position;
				//position.y = Mathf.Sin(Mathf.PI * (position.x + position.z + Time.time));
				position.y = sine2D(position.x, position.z, Time.time);

				point.localPosition = position;
			}
		}




	
	}

	static float sine2D(float x, float z, float t){
		float y = Mathf.Sin(Mathf.PI * (x + t));
		y += Mathf.Sin(Mathf.PI * (z + t));
		y *= 0.5f;
		return y;
	}
}
