using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPlayClicked(){
	
		SceneManager.LoadScene ("ConnectionMenu");
		Cursor.visible = false;
	}

	public void OnHowToPlayClicked(){
		SceneManager.LoadScene ("HowToPlay_scene");
		Cursor.visible = false;
	}
}
