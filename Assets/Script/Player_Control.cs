using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

	public Chess_behaveiour chess_Behaveiour_refference;

	public raycast raycast_Refference;

	public GameObject KingW, KingB;

	public Pause_Menu win_Menu_Refference;

	public int currently_White = 1;

	public void swith_Player (){

		if (currently_White == 1) {
			currently_White = 0;

			if (KingB.GetComponent<Pice> ().check_Danger (KingB.GetComponent<Pice> ().position_X, KingB.GetComponent<Pice> ().position_Y, chess_Behaveiour_refference.chess_Table)) {
				bool can_Move = false;
				for (int i = 0; i <= 7 && can_Move != true; ++i) {
					for (int j = 0; j <= 7 && can_Move != true; ++j) {
						if (chess_Behaveiour_refference.chess_Table [i] [j] != null && chess_Behaveiour_refference.chess_Table [i] [j].name.Contains ("W") == false) {
							int temp = chess_Behaveiour_refference.chess_Table [i] [j].GetComponent<Pice> ().Select (false);
							chess_Behaveiour_refference.chess_Table [i] [j].GetComponent<Pice> ().Deselect ();
							if (temp >= 1) {
								can_Move = true;
							}
						}
					}
				}

				if (can_Move) {
					KingB.GetComponent<Pice> ().Select (true);
					raycast_Refference.currently_Selected = KingB;
					raycast_Refference.in_Check = true;
				} else {
					win_Menu_Refference.Win (!((currently_White == 1) ? true : false));
				}

			}

		} else {
			currently_White = 1;

			if (KingW.GetComponent<Pice> ().check_Danger (KingW.GetComponent<Pice> ().position_X, KingW.GetComponent<Pice> ().position_Y, chess_Behaveiour_refference.chess_Table)) {
				bool can_Move = false;
				for (int i = 0; i <= 7 && can_Move != true; ++i) {
					for (int j = 0; j <= 7 && can_Move != true; ++j) {
						if (chess_Behaveiour_refference.chess_Table [i] [j] != null && chess_Behaveiour_refference.chess_Table [i] [j].name.Contains ("W") == true) {
							int temp = chess_Behaveiour_refference.chess_Table [i] [j].GetComponent<Pice> ().Select (false);
							chess_Behaveiour_refference.chess_Table [i] [j].GetComponent<Pice> ().Deselect ();
							if (temp >= 1) {
								can_Move = true;
							}
						}
					}
				}

				if (can_Move) {
					KingW.GetComponent<Pice> ().Select (true);
					raycast_Refference.currently_Selected = KingW;
					raycast_Refference.in_Check = true;
				} else {
					win_Menu_Refference.Win (!((currently_White == 1) ? true : false));
				}

			}

		}
			
	}

}
