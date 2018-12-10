using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector_circle : MonoBehaviour {

	float speed = 10;

	Vector3 end_Marker;

	void Start () {

		end_Marker = transform.position;

	}

	void Update () {

		transform.position = Vector3.Lerp (transform.position, end_Marker, Time.deltaTime * speed);

	}

	public void move_To (Vector3 _end_Marker) {

		end_Marker = new Vector3 (_end_Marker.x, 0.0F, _end_Marker.z);

	}
		
	public void move_Away () {
		
		transform.position = new Vector3 (0.0f, 0.0f, 20.0f);
		move_To (transform.position);

	}


}
