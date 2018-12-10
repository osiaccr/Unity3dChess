using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pice : MonoBehaviour {

	public bool is_White;

	public static float move_Distance = 1.0F;

	public int position_X, position_Y;

	public int moves = 0;

	public Chess_behaveiour chess_Behaveiour_refference;

	public GameObject destroyer_Refference;

	List<GameObject> markers = new List<GameObject> ();

	List<GameObject> destroy_Markers = new List<GameObject> ();

	int[] vertical_Horizontal_i = { 1, -1, 0, 0 };
	int[] vertical_Horizontal_j = { 0, 0, 1, -1 };

	int[] diagonal_i = {1, 1, -1, -1};
	int[] diagonal_j = {-1, 1, 1, -1};

	int[] horse_i = { -2, -2, -1, 1, 2, 2, 1, -1 };
	int[] horse_j = { -1, 1, 2, 2, 1, -1, -2, -2 };

	int[] diagonal_Vertical_Horizontal_i = { -1, -1, 0, 1, 1, 1, 0, -1 };
	int[] diagonal_Vertical_Horizontal_j = { 0, 1, 1, 1, 0, -1, -1, -1 };

	void Start () {
		
		if (this.name.Contains ("W")) {
			is_White = true;
		}

	}
	
	private void create_New_Marker (Vector3 position_Vector3, int marker_Position_X, int marker_Position_Y) {
		
		GameObject marker = new GameObject ();
		marker.AddComponent<MeshFilter> ();
		marker.GetComponent<MeshFilter> ().mesh = GetComponent<MeshFilter> ().mesh;
		marker.AddComponent<MeshRenderer> ();
		marker.GetComponent<MeshRenderer> ().material = Resources.Load ("Transparent_Marker", typeof(Material)) as Material;
		marker.AddComponent<MeshCollider> ();
		marker.transform.SetParent (transform, true);
		marker.transform.position = new Vector3 (position_Vector3.x, position_Vector3.y, position_Vector3.z);
		marker.AddComponent<Marker> ();
		marker.GetComponent<Marker> ().position_X = marker_Position_X;
		marker.GetComponent<Marker> ().position_Y = marker_Position_Y;
		marker.transform.localScale = new Vector3 (1F, 1F, 1F);
		marker.transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
		marker.name = "Marker";
		markers.Add (marker);

	}

	private void create_New_Destroy_Marker (GameObject target, int destroy_Marker_Position_X, int destroy_Marker_Position_Y) {

		GameObject marker = new GameObject ();
		marker.AddComponent<MeshFilter> ();
		marker.GetComponent<MeshFilter> ().mesh = target.GetComponent<MeshFilter> ().mesh;
		marker.AddComponent<MeshRenderer> ();
		marker.GetComponent<MeshRenderer> ().material = Resources.Load ("Red", typeof(Material)) as Material;
		marker.AddComponent<MeshCollider> ();
		marker.transform.localScale = target.transform.lossyScale;
		marker.transform.rotation = target.transform.rotation;
		marker.transform.SetParent (transform, true);
		marker.transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, target.transform.position.z);
		marker.AddComponent<Destroy_Marker> ();
		marker.GetComponent<Destroy_Marker> ().position_X = destroy_Marker_Position_X;
		marker.GetComponent<Destroy_Marker> ().position_Y = destroy_Marker_Position_Y;
		marker.GetComponent<Destroy_Marker> ().target = target;
		target.SetActive (false);
		marker.name = "Destroy_Marker";
		destroy_Markers.Add (marker);

	}

	public void move_To_Marker (Transform marker_Transform) {
		
		transform.position = new Vector3 (marker_Transform.position.x, transform.position.y, marker_Transform.position.z);
		chess_Behaveiour_refference.chess_Table [position_X] [position_Y] = null;
		position_X = marker_Transform.GetComponent<Marker> ().position_X;
		position_Y = marker_Transform.GetComponent<Marker> ().position_Y;
		chess_Behaveiour_refference.chess_Table [position_X] [position_Y] = gameObject;

		++moves;

	}

	public void move_To_Destroy_Marker (Transform marker_Transform) {

		transform.position = new Vector3 (marker_Transform.position.x, transform.position.y, marker_Transform.position.z);
		chess_Behaveiour_refference.chess_Table [position_X] [position_Y] = null;
		position_X = marker_Transform.GetComponent<Destroy_Marker> ().position_X;
		position_Y = marker_Transform.GetComponent<Destroy_Marker> ().position_Y;
		chess_Behaveiour_refference.chess_Table [position_X] [position_Y] = gameObject;

		++moves;

	}

	private void create_New_Castling_Marker (Vector3 position_Vector3, int castlig_Marker_Position_X, int castlig_Marker_Position_Y, GameObject turret, Vector3 turret_Position_Vector3, int turret_Position_X, int turret_Position_Y) {

		GameObject marker = new GameObject ();
		marker.AddComponent<MeshFilter> ();
		marker.GetComponent<MeshFilter> ().mesh = GetComponent<MeshFilter> ().mesh;
		marker.AddComponent<MeshRenderer> ();
		marker.GetComponent<MeshRenderer> ().material = Resources.Load ("Transparent_Marker", typeof(Material)) as Material;
		marker.AddComponent<MeshCollider> ();
		marker.transform.SetParent (transform, true);
		marker.transform.position = new Vector3 (position_Vector3.x, position_Vector3.y, position_Vector3.z);
		marker.AddComponent<Castling_Marker> ();
		marker.GetComponent<Castling_Marker> ().position_X = castlig_Marker_Position_X;
		marker.GetComponent<Castling_Marker> ().position_Y = castlig_Marker_Position_Y;
		marker.GetComponent<Castling_Marker> ().turret = turret;
		marker.GetComponent<Castling_Marker> ().turret_Position_Vector3 = turret_Position_Vector3;
		marker.GetComponent<Castling_Marker> ().turret_Position_X = turret_Position_X;
		marker.GetComponent<Castling_Marker> ().turret_Position_Y = turret_Position_Y;
		marker.transform.localScale = new Vector3 (1F, 1F, 1F);
		marker.transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
		marker.name = "Castling_Marker";
		markers.Add (marker);

	}

	public void move_To_Castling_Marker (Transform marker_Transform) {

		transform.position = new Vector3 (marker_Transform.position.x, transform.position.y, marker_Transform.position.z);
		chess_Behaveiour_refference.chess_Table [position_X] [position_Y] = null;
		position_X = marker_Transform.GetComponent<Castling_Marker> ().position_X;
		position_Y = marker_Transform.GetComponent<Castling_Marker> ().position_Y;
		chess_Behaveiour_refference.chess_Table [position_X] [position_Y] = gameObject;

		++moves;

		marker_Transform.GetComponent<Castling_Marker> ().turret.transform.position = marker_Transform.GetComponent<Castling_Marker> ().turret_Position_Vector3;
		chess_Behaveiour_refference.chess_Table [marker_Transform.GetComponent<Castling_Marker> ().turret.GetComponent<Pice> ().position_X] [marker_Transform.GetComponent<Castling_Marker> ().turret.GetComponent<Pice> ().position_Y] = null;
		marker_Transform.GetComponent<Castling_Marker> ().turret.GetComponent<Pice> ().position_X = marker_Transform.GetComponent<Castling_Marker> ().turret_Position_X;
		marker_Transform.GetComponent<Castling_Marker> ().turret.GetComponent<Pice> ().position_Y = marker_Transform.GetComponent<Castling_Marker> ().turret_Position_Y;
		chess_Behaveiour_refference.chess_Table [marker_Transform.GetComponent<Castling_Marker> ().turret.GetComponent<Pice> ().position_X] [marker_Transform.GetComponent<Castling_Marker> ().turret.GetComponent<Pice> ().position_Y] = marker_Transform.GetComponent<Castling_Marker> ().turret;

		++marker_Transform.GetComponent<Castling_Marker> ().turret.GetComponent<Pice> ().moves;

	}


	private bool check_Danger_Simulated_Move (int new_X, int new_Y, GameObject[][] chess_Table, int check_Position_X, int check_Position_Y) {
		GameObject prev_New_Pos = null;
		if (chess_Table [new_X] [new_Y] != null) {
			prev_New_Pos = chess_Table [new_X] [new_Y];
		}
		chess_Table [new_X] [new_Y] = gameObject;
		chess_Table [position_X] [position_Y] = null;
		bool danger = check_Danger (check_Position_X, check_Position_Y, chess_Table);
		chess_Table [position_X] [position_Y] = gameObject;
		chess_Table [new_X] [new_Y] = prev_New_Pos;
		return danger;
	}


	public int Select (bool in_Check) {
		
		if (in_Check == false) {
			this.GetComponent<Renderer> ().material.color = new Color (0.5F, 0.5F, 0.5F);
		} else {
			this.GetComponent<Renderer> ().material.color = Color.red;
		}

		if (name.Contains ("Pawn")) {

			if (is_White) {
				int new_X = position_X - 1, new_Y = position_Y;

				if (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8 && chess_Behaveiour_refference.chess_Table [new_X] [new_Y] == null && check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
					create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
				}

				new_X = position_X - 2;

				if (moves == 0 && new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8 && chess_Behaveiour_refference.chess_Table [new_X] [new_Y] == null && check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
					create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
				}

				new_X = position_X - 1; new_Y = position_Y - 1;

				if (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8 && chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null && chess_Behaveiour_refference.chess_Table[new_X][new_Y].name.Contains ("W") != is_White && check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
					create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
				}

				new_Y = position_Y + 1;

				if (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8 && chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null && chess_Behaveiour_refference.chess_Table[new_X][new_Y].name.Contains ("W") != is_White && check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
					create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
				}
			} else {
				int new_X = position_X + 1, new_Y = position_Y;

				if (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8 && chess_Behaveiour_refference.chess_Table [new_X] [new_Y] == null && check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
					create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
				}

				new_X = position_X + 2;

				if (moves == 0 && new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8 && chess_Behaveiour_refference.chess_Table [new_X] [new_Y] == null && check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
					create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
				}

				new_X = position_X + 1; new_Y = position_Y - 1;

				if (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8 && chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null && chess_Behaveiour_refference.chess_Table[new_X][new_Y].name.Contains ("W") != is_White && check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
					create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
				}

				new_Y = position_Y + 1;

				if (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8 && chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null && chess_Behaveiour_refference.chess_Table[new_X][new_Y].name.Contains ("W") != is_White && check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
					create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
				}
			}

		}

		if (name.Contains ("Turret")) {

			for (int d = 0; d <= 3; ++d) {

				int new_X = position_X + vertical_Horizontal_i[d], new_Y = position_Y + vertical_Horizontal_j[d];
				while (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8) {
					if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null && chess_Behaveiour_refference.chess_Table [new_X] [new_Y].GetComponent<Pice> ().is_White == is_White) {
						break;
					}
					if (check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
						if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null) {
							if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) {
								create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
							}
							break;
						}
						create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
					}
					new_X = new_X + vertical_Horizontal_i [d];
					new_Y = new_Y + vertical_Horizontal_j [d];
				}
			}

		}

		if (name.Contains ("Bishop")) {

			for (int d = 0; d <= 3; ++d) {

				int new_X = position_X + diagonal_i[d], new_Y = position_Y + diagonal_j[d];
				while (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8) {
					if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null && chess_Behaveiour_refference.chess_Table [new_X] [new_Y].GetComponent<Pice> ().is_White == is_White) {
						break;
					}
					if (check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
						if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null) {
							if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) {
								create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
							}
							break;
						}
						create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
					}
					new_X = new_X + diagonal_i [d];
					new_Y = new_Y + diagonal_j [d];
				}
			}

		}

		if (name.Contains ("Horse")) {

			for (int d = 0; d <= 7; ++d) {

				int new_X = position_X + horse_i[d], new_Y = position_Y + horse_j[d];
				if (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8)  {
					if (check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
						if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y] == null) {
							create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
						} else {
							if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) {
								create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
							}
						}
					}
				}
			}

		}

		if (name.Contains ("Queen")) {

			for (int d = 0; d <= 7; ++d) {

				int new_X = position_X + diagonal_Vertical_Horizontal_i[d], new_Y = position_Y + diagonal_Vertical_Horizontal_j[d];
				while (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8) {
					if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null && chess_Behaveiour_refference.chess_Table [new_X] [new_Y].GetComponent<Pice> ().is_White == is_White) {
						break;
					}
					if (check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, (is_White) ? chess_Behaveiour_refference.king_Position_W_X : chess_Behaveiour_refference.king_Position_B_X, (is_White) ? chess_Behaveiour_refference.king_Position_W_Y : chess_Behaveiour_refference.king_Position_B_Y) == false) {
						if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y] != null) {
							if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) {
								create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
							}
							break;
						}
						create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
					}
					new_X = new_X + diagonal_Vertical_Horizontal_i [d];
					new_Y = new_Y + diagonal_Vertical_Horizontal_j [d];
				}
			}

		}

		if (name.Contains ("King")) {

			for (int d = 0; d <= 7; ++d) {

				int new_X = position_X + diagonal_Vertical_Horizontal_i[d], new_Y = position_Y + diagonal_Vertical_Horizontal_j[d];
				if (new_X >= 0 && new_X < 8 && new_Y >= 0 && new_Y < 8)  {
					if (check_Danger_Simulated_Move (new_X, new_Y, chess_Behaveiour_refference.chess_Table, new_X, new_Y) == false) {
						if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y] == null) {
							create_New_Marker (new Vector3 (transform.position.x + (position_X - new_X) * move_Distance, transform.position.y, transform.position.z + (position_Y - new_Y) * move_Distance), new_X, new_Y);
						} else {
							if (chess_Behaveiour_refference.chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) {
								create_New_Destroy_Marker (chess_Behaveiour_refference.chess_Table[new_X][new_Y], new_X, new_Y);
							}
						}
					}
				}

			}

			// Castling

			
			if (moves == 0 &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 1] == null &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 2] == null &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3] != null &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3].name.Contains ("Turret") &&
				chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3].name.Contains ("W") == is_White &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y].GetComponent<Pice> ().moves == 0 &&
			    !check_Danger (position_X, position_Y + 2, chess_Behaveiour_refference.chess_Table)) {

				create_New_Castling_Marker (new Vector3 (transform.position.x, transform.position.y, transform.position.z - 2 * move_Distance), 
					position_X, position_Y + 2,
					chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3],
					new Vector3 (chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3].transform.position.x, chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3].transform.position.y, chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3].transform.position.z + 2 * move_Distance),
					chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3].GetComponent<Pice> ().position_X, chess_Behaveiour_refference.chess_Table [position_X] [position_Y + 3].GetComponent<Pice> ().position_Y - 2
				);

			}

			if (moves == 0 &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 1] == null &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 2] == null &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 3] == null &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4] != null &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4].name.Contains ("Turret") &&
				chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4].name.Contains ("W") == is_White &&
			    chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4].GetComponent<Pice> ().moves == 0 &&
			    !check_Danger (position_X, position_Y - 2, chess_Behaveiour_refference.chess_Table)) {

				create_New_Castling_Marker (new Vector3 (transform.position.x, transform.position.y, transform.position.z + 2 * move_Distance),
					position_X, position_Y - 2,
					chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4],
					new Vector3 (chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4].transform.position.x, chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4].transform.position.y, chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4].transform.position.z - 3 * move_Distance),
					chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4].GetComponent<Pice> ().position_X, chess_Behaveiour_refference.chess_Table [position_X] [position_Y - 4].GetComponent<Pice> ().position_Y + 3
				);

			}
		
		} 
			

		return markers.Count;

	}

	public void Deselect () {
		
		if (is_White) {
			this.GetComponent<Renderer> ().material.color = Color.white;
		} else {
			this.GetComponent<Renderer> ().material.color = Color.black;
		}

		for (int i = 0; i < markers.Count ; ++i) {
			GameObject.Destroy (markers [i]);
		}
		markers.Clear ();

		for (int i = 0; i < destroy_Markers.Count; ++i) {
			destroy_Markers [i].GetComponent<Destroy_Marker> ().target.SetActive (true);
			GameObject.Destroy (destroy_Markers [i]);
		}
		destroy_Markers.Clear ();
	}

	public bool check_Danger (int check_Position_X, int check_Position_Y, GameObject[][] chess_Table) {

		// Pawns 
		if (is_White == true) {
			int new_X = check_Position_X - 1, new_Y = check_Position_Y - 1;

			if ((new_X >= 0) && (new_X <= 7) && (new_Y >= 0) && (new_Y <= 7) && (chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("Pawn")) {
				return true;
			}

			new_Y = check_Position_Y + 1;

			if ((new_X >= 0) && (new_X <= 7) && (new_Y >= 0) && (new_Y <= 7) && (chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("Pawn")) {
				return true;
			}
		} else {
			int new_X = check_Position_X + 1, new_Y = check_Position_Y - 1;

			if ((new_X >= 0) && (new_X <= 7) && (new_Y >= 0) && (new_Y <= 7) && (chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("Pawn")) {
				return true;
			}

			new_Y = check_Position_Y + 1;

			if ((new_X >= 0) && (new_X <= 7) && (new_Y >= 0) && (new_Y <= 7) && (chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("Pawn")) {
				return true;
			}
		}

		// Bishops
		for (int d = 0; d <= 3; ++d) {

			int new_X = check_Position_X + diagonal_i [d] ,new_Y = check_Position_Y + diagonal_j [d];

			while ((new_X >= 0) && (new_X <= 7) && (new_Y >= 0) && (new_Y <= 7)) {
				if ((chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("Bishop") == false)) {
					break;
				}
				if ((chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("Bishop")) {
					return true;
				}
				new_X = new_X + diagonal_i [d];
				new_Y = new_Y + diagonal_j [d];
			}

		}

		// Turrets
		for (int d = 0; d <= 3; ++d) {
		
			int new_X = check_Position_X + vertical_Horizontal_i [d] ,new_Y = check_Position_Y + vertical_Horizontal_j [d];

			while ((new_X >= 0) && (new_X <= 7) && (new_Y >= 0) && (new_Y <= 7)) {
				if ((chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("Turret") == false)) {
					break;
				}
				if ((chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("Turret")) {
					return true;
				}
				new_X = new_X + vertical_Horizontal_i [d];
				new_Y = new_Y + vertical_Horizontal_j [d];
			}

		}

		// Horses
		for (int d = 0; d <= 3; ++d) {

			int new_X = check_Position_X + horse_i [d] ,new_Y = check_Position_Y + horse_j [d];

			if ((new_X >= 0) && (new_X < 7) && (new_Y >= 0) && (new_Y < 7) && (chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("Horse")) {
				return true;
			}
				
		}

		// Queen
		for (int d = 0; d <= 7; ++d) {

			int new_X = check_Position_X + diagonal_Vertical_Horizontal_i [d] ,new_Y = check_Position_Y + diagonal_Vertical_Horizontal_j [d];

			while ((new_X >= 0) && (new_X <= 7) && (new_Y >= 0) && (new_Y <= 7)) {
				if ((chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("Queen") == false)) {
					break;
				}
				if ((chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("Queen")) {
					return true;
				}
				new_X = new_X + diagonal_Vertical_Horizontal_i [d];
				new_Y = new_Y + diagonal_Vertical_Horizontal_j [d];
			}

		}

		// King
		for (int d = 0; d <= 7; ++d) {

			int new_X = check_Position_X + diagonal_Vertical_Horizontal_i [d], new_Y = check_Position_Y + diagonal_Vertical_Horizontal_j [d];

			if ((new_X >= 0) && (new_X < 7) && (new_Y >= 0) && (new_Y < 7) && (chess_Table [new_X] [new_Y] != null) && (chess_Table [new_X] [new_Y].name.Contains ("W") != is_White) && chess_Table [new_X] [new_Y].name.Contains ("King")) {
				return true;
			}

		}

		return false;

	}

}