using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMenu : MonoBehaviour {

	public GameObject Menu;

	public void OnStartClicked(){
		Menu.SetActive(false);
		SceneManager.LoadScene("Arena1");
	}

	public void EnterName(){
		
	}


}
