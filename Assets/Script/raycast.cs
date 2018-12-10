using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour {

	public GameObject currently_Selected = null;

	public bool in_Check = false;

	public Selector_circle Selector_circle_script;

	public Chess_behaveiour chess_Behaveiour_refference;

	public Player_Control player_Controll_refference;

	void Update(){
		if (Input.GetMouseButtonDown(0)){ 

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)){

				if (hit.collider.name == "Marker") {

					hit.transform.GetComponentInParent<Pice> ().move_To_Marker (hit.transform);
					if (hit.transform.GetComponentInParent<Pice> ().name.Contains ("King")) {
						if (hit.transform.GetComponentInParent<Pice> ().is_White == true) {
							chess_Behaveiour_refference.king_Position_W_X = hit.transform.GetComponent<Marker> ().position_X;
							chess_Behaveiour_refference.king_Position_W_Y = hit.transform.GetComponent<Marker> ().position_Y;
						} else {
							chess_Behaveiour_refference.king_Position_B_X = hit.transform.GetComponent<Marker> ().position_X;
							chess_Behaveiour_refference.king_Position_B_Y = hit.transform.GetComponent<Marker> ().position_Y;
						}
					}

					if (currently_Selected != null) {
						currently_Selected.GetComponent<Pice> ().Deselect ();
					}

					Selector_circle_script.move_Away ();

					if (in_Check == true) {
						in_Check = false;
					}

					player_Controll_refference.swith_Player ();

				} 
				else {

					if (hit.collider.name == "Destroy_Marker") {

						int position_X = hit.transform.GetComponent<Destroy_Marker> ().position_X;
						int position_Y = hit.transform.GetComponent<Destroy_Marker> ().position_Y;

						GameObject.Destroy (chess_Behaveiour_refference.chess_Table[position_X][position_Y]);

						hit.transform.GetComponentInParent<Pice> ().move_To_Destroy_Marker (hit.transform);
						if (hit.transform.GetComponentInParent<Pice> ().name.Contains ("King")) {
							if (hit.transform.GetComponentInParent<Pice> ().is_White == true) {
								chess_Behaveiour_refference.king_Position_W_X = hit.transform.GetComponent<Destroy_Marker> ().position_X;
								chess_Behaveiour_refference.king_Position_W_Y = hit.transform.GetComponent<Destroy_Marker> ().position_Y;
							} else {
								chess_Behaveiour_refference.king_Position_B_X = hit.transform.GetComponent<Destroy_Marker> ().position_X;
								chess_Behaveiour_refference.king_Position_B_Y = hit.transform.GetComponent<Destroy_Marker> ().position_Y;
							}
						}

						if (currently_Selected != null) {
							currently_Selected.GetComponent<Pice> ().Deselect ();
						}

						Selector_circle_script.move_Away ();

						if (in_Check == true) {
							in_Check = false;
						}

						player_Controll_refference.swith_Player ();

					} else {

						if (hit.collider.name == "Castling_Marker") {

							hit.transform.GetComponentInParent<Pice> ().move_To_Castling_Marker (hit.transform);
							if (hit.transform.GetComponentInParent<Pice> ().name.Contains ("King")) {
								if (hit.transform.GetComponentInParent<Pice> ().is_White == true) {
									chess_Behaveiour_refference.king_Position_W_X = hit.transform.GetComponent<Marker> ().position_X;
									chess_Behaveiour_refference.king_Position_W_Y = hit.transform.GetComponent<Marker> ().position_Y;
								} else {
									chess_Behaveiour_refference.king_Position_B_X = hit.transform.GetComponent<Marker> ().position_X;
									chess_Behaveiour_refference.king_Position_B_Y = hit.transform.GetComponent<Marker> ().position_Y;
								}
							}

							if (currently_Selected != null) {
								currently_Selected.GetComponent<Pice> ().Deselect ();
							}

							Selector_circle_script.move_Away ();

							if (in_Check == true) {
								in_Check = false;
							}

							player_Controll_refference.swith_Player ();

						}

						else {

							bool currently_White_Bool = player_Controll_refference.currently_White == 1 ? true : false;

							if (hit.collider.name.Contains ("W") == currently_White_Bool) {

								if (currently_Selected != null) {
									currently_Selected.GetComponent<Pice> ().Deselect ();
								}

								hit.collider.GetComponent<Pice> ().Select (false);
								Selector_circle_script.move_To (hit.transform.position);

								currently_Selected = hit.collider.gameObject;

							}

						}

					}

				}
			}
		}
	}
}
