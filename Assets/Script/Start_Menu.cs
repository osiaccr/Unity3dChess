using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour {

	public GameObject pause_Menu_Canvas;

	public GameObject scene_Selector_Canvas;

	private int game_Scene_Space_Id = 1;

	private int game_Scene_Forest_Id = 2;


	public void select_Secene_Selector () {
		pause_Menu_Canvas.SetActive (false);
		scene_Selector_Canvas.SetActive (true);
	}

	public void select_Pause_Menu () {
		pause_Menu_Canvas.SetActive (true);
		scene_Selector_Canvas.SetActive (false);
	}

	public void select_Game_Scene_Space () {
		SceneManager.LoadScene (game_Scene_Space_Id);
	}

	public void select_Game_Scene_Forest () {	
		SceneManager.LoadScene (game_Scene_Forest_Id);
	}

	public void Quit () {
		Application.Quit ();
	}

}
