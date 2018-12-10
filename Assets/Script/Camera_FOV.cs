using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FOV : MonoBehaviour {

	public int zoomSpeed = 0;

	void Update () {

		GetComponent<Camera> ().fieldOfView -= Time.deltaTime * Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;

	}
}
