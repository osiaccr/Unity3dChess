using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

	private bool is_Paused = false;

	private const int game_Scene_Space_Id = 1;

	private const int game_Scene_Forest_Id = 2;

	private const int main_Menu_Scene_Index = 0;

	public GameObject pause_Menu_Canvas;

	public GameObject win_Menu_Canvas;

	public GameObject scene_Selector_Canvas;

	public GameObject white_Wins;

	public GameObject black_Wins;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (is_Paused) {
				Unpause ();
			}
			else {
				Pause ();
			}
		}
	}

	void Pause () {		
		is_Paused = true;
		Time.timeScale = 0;
		pause_Menu_Canvas.SetActive (true);
	}
		
	public void Unpause () {
		is_Paused = false;
		Time.timeScale = 1;
		pause_Menu_Canvas.SetActive (false);
	}

	public void Restart () {
		Unpause ();
		pause_Menu_Canvas.SetActive (false);
		scene_Selector_Canvas.SetActive (true);
	}

	public void Main_Menu () {
		SceneManager.LoadScene (main_Menu_Scene_Index);
	}

	public void Menu () {

	}

	public void Win (bool is_White) {
		win_Menu_Canvas.SetActive (true);
		if (is_White) {
			white_Wins.SetActive (true);
		} else {
			black_Wins.SetActive (true);
		}
	}

	public void select_Game_Scene_Space () {
		SceneManager.LoadScene (game_Scene_Space_Id);
	}

	public void select_Game_Scene_Forest () {	
		SceneManager.LoadScene (game_Scene_Forest_Id);
	}

	public void Back () {
		scene_Selector_Canvas.SetActive (false);
		pause_Menu_Canvas.SetActive (true);
	}

}
