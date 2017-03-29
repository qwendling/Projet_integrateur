using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMenu : MonoBehaviour {

	public GameObject Menu;
	public Button StartButton;

	public void Start (){
		Cursor.visible = true;
		/*
		StartButton.transform.localScale = new Vector3(
			StartButton.transform.localScale.x,
			(Screen.height*(1.0f/12.0f)),
			StartButton.transform.localScale.z);
			*/

		StartButton.GetComponent<RectTransform> ().rect.Set (
			StartButton.GetComponent<RectTransform> ().rect.x,
			StartButton.GetComponent<RectTransform> ().rect.y,
			StartButton.GetComponent<RectTransform> ().rect.width,
			Screen.height * (1.0f / 12.0f));
		
	}

	public void OnStartClicked(){
		Menu.SetActive(false);
		SceneManager.LoadScene("Arena1");
	}

	public void EnterName(){
		
	}


}
