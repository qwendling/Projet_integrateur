﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

	public GameObject _inGameMenu;
	//public GameObject _inGameUI;
	public GameObject _Player;
	private bool display = false;


	// Use this for initialization
	void Start () {
		_inGameMenu.SetActive (false);
		//_inGameUI.SetActive (true);
		display = false;
		Time.timeScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			//If the menu was not displayed, then display it
			if (display == false) {				
				_inGameMenu.SetActive (true);
				//_inGameUI.SetActive (false);
				_Player.GetComponent<PlayerController> ()._InGameMenuIsDisplayed = true;
				display = true;
				Cursor.visible = true;
			} 
			//If the menu was displayed, then do not display it anymore
			else {
				_inGameMenu.SetActive (false);
				//_inGameUI.SetActive (true);
				_Player.GetComponent<PlayerController> ()._InGameMenuIsDisplayed = false;
				display = false;
				Cursor.visible = false;
			}
		}
	}

	public void OnResumeClicked(){
		_inGameMenu.SetActive (false);
		//_inGameUI.SetActive (true);
		_Player.GetComponent<PlayerController> ()._InGameMenuIsDisplayed = false;
		display = false;
	}

	public void OnMainMenuClicked(){
		SceneManager.LoadScene ("MainMenu_scene");
		Cursor.visible = true;
	}
	
}
