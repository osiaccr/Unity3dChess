using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess_behaveiour : MonoBehaviour {

	/* 

	This contains all the chess mechanics

	chess_Table is 2d vector of GameObject, containing the placement of the pices on the table
	and refrences to all pices layed out as seen for the view of the withes
	
	*/

	public GameObject BishopW1, BishopW2, BishopB1, BishopB2, HorseW1, HorseW2, HorseB1, HorseB2, TurretW1, TurretW2, TurretB1, TurretB2, QueenW, QueenB, KingW, KingB, PawnW1, PawnW2, PawnW3, PawnW4, PawnW5, PawnW6, PawnW7, PawnW8, PawnB1, PawnB2, PawnB3, PawnB4, PawnB5, PawnB6, PawnB7, PawnB8;

	public GameObject[][] chess_Table;

	public int king_Position_W_X, king_Position_W_Y, king_Position_B_X, king_Position_B_Y;

	void Start () {

		king_Position_W_X = 7; king_Position_W_Y = 3; king_Position_B_X = 0; king_Position_B_Y = 4;

		chess_Table = new GameObject[][]
		{	new GameObject[] {TurretB2, HorseB1, BishopB2, QueenB, KingB, BishopB1, HorseB2, TurretB1 },
			new GameObject[] {PawnB8, PawnB7, PawnB6, PawnB5, PawnB4, PawnB3, PawnB2, PawnB1},
			new GameObject[] {null, null, null, null, null, null, null, null},
			new GameObject[] {null, null, null, null, null, null, null, null},
			new GameObject[] {null, null, null, null, null, null, null, null},
			new GameObject[] {null, null, null, null, null, null, null, null},
			new GameObject[] {PawnW1, PawnW2, PawnW3, PawnW4, PawnW5, PawnW6, PawnW7, PawnW8},
			new GameObject[] {TurretW1, HorseW1, BishopW1, QueenW, KingW, BishopW2, HorseW2, TurretW2 },
		};

	}

}
