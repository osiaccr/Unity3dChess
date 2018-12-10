using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Orbit : MonoBehaviour {

	private const float MIN_Y = 0.0f;
	private const float MAX_Y = 89.9f;
	
	public GameObject orbitTarget;

	public float rotateSpeed = 0.0f;
	public float distance = 10.0f;

	private float current_X = 90.0f;
	private float current_Y = 50.0f;

	void Update () {
		current_X -=  Input.GetAxis ("Horizontal");
		current_Y += Input.GetAxis ("Vertical");

		if (Input.GetMouseButton (1)) { // RightClick
			current_X += Input.GetAxis ("Mouse X");
			current_Y -= Input.GetAxis ("Mouse Y");
		}

		current_Y = Mathf.Clamp (current_Y, MIN_Y, MAX_Y);
	}

	void LateUpdate () {

		transform.position = orbitTarget.transform.position + Quaternion.Euler (current_Y, current_X, 0) * new Vector3 (0, 0, -distance);
		transform.LookAt (orbitTarget.transform);

		/*transform.LookAt (orbitTarget.transform);

		if (Input.GetAxis ("Horizontal") == -1) { // Rotate Left
			transform.RotateAround (orbitTarget.transform.position, Vector3.up, Time.deltaTime * rotateSpeed);
		}

		if (Input.GetAxis ("Horizontal") == 1) { // Rotate Right
			transform.RotateAround (orbitTarget.transform.position, -Vector3.up, Time.deltaTime * rotateSpeed);
		}

		if (Input.GetAxis ("Vertical") == 1) { // Rotate Up
			transform.RotateAround (orbitTarget.transform.position, new Vector3 (0, 0, 1), Time.deltaTime * rotateSpeed);
		}

		if (Input.GetAxis ("Vertical") == -1) { // Rotate Down
			transform.RotateAround (orbitTarget.transform.position, -new Vector3 (0, 0, 1), Time.deltaTime * rotateSpeed);
		}*/

	}
}
