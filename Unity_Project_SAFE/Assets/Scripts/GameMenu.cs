using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMenu : MonoBehaviour {

	public GameObject Menu;
	public Button StartButton;
	public GameObject Model_menu;
	public GameObject Weapons_Menu;
	public GameObject PlayerChoices;

	public void Start (){
		Cursor.visible = true;
		/*
		StartButton.transform.localScale = new Vector3(
			StartButton.transform.localScale.x,
			(Screen.height*(1.0f/12.0f)),
			StartButton.transform.localScale.z);
			*/
		/*
		StartButton.GetComponent<RectTransform> ().rect.Set (
			StartButton.GetComponent<RectTransform> ().rect.x,
			StartButton.GetComponent<RectTransform> ().rect.y,
			StartButton.GetComponent<RectTransform> ().rect.width,
			Screen.height * (1.0f / 12.0f));
		*/
	}

	public void OnStartClicked(){
		Menu.SetActive(false);
		PlayerChoices.GetComponent<PlayerChoices> ()._Model = Model_menu.GetComponent<Menu_ModelChoice> ()._Models [Model_menu.GetComponent<Menu_ModelChoice> ().Models_index];
		PlayerChoices.GetComponent<PlayerChoices> ()._Wep1 = Weapons_Menu.GetComponent<Menu_WeaponsChoice> ()._Weapons [Weapons_Menu.GetComponent<Menu_WeaponsChoice> ().Weapon1_index];
		PlayerChoices.GetComponent<PlayerChoices> ()._Wep2 = Weapons_Menu.GetComponent<Menu_WeaponsChoice> ()._Weapons [Weapons_Menu.GetComponent<Menu_WeaponsChoice> ().Weapon2_index];
		PlayerChoices.GetComponent<PlayerChoices> ()._Wep3 = Weapons_Menu.GetComponent<Menu_WeaponsChoice> ()._Weapons [Weapons_Menu.GetComponent<Menu_WeaponsChoice> ().Weapon3_index];
		DontDestroyOnLoad (PlayerChoices);
		SceneManager.LoadScene("Arena1");
	}

	public void EnterName(){
		
	}


}
