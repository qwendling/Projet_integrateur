<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_ModelChoice : MonoBehaviour {

	public static int NumberOfAvailableModels = 2;
	public GameObject[] _Models = new GameObject[NumberOfAvailableModels];
	public GameObject _ModelPreview;

	public int Models_index = 0;


	// Use this for initialization
	void Start () {
		_ModelPreview.GetComponent<Image> ().sprite = _Models [Models_index].GetComponent<ModelPreviewReferencing>()._ModelSprite;
	}
	
	public void OnModelUpClicked(){
		if (Models_index < NumberOfAvailableModels - 1) {
			Models_index++;
		} else {
			Models_index = 0;
		}
		_ModelPreview.GetComponent<Image> ().sprite = _Models [Models_index].GetComponent<ModelPreviewReferencing>()._ModelSprite;
	}

	public void OnModelDownClicked(){
		if (Models_index > 0) {
			Models_index--;
		} else {
			Models_index = NumberOfAvailableModels - 1;
		}
		_ModelPreview.GetComponent<Image> ().sprite = _Models [Models_index].GetComponent<ModelPreviewReferencing>()._ModelSprite;
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_ModelChoice : MonoBehaviour {

	public static int NumberOfAvailableModels = 2;
	public GameObject[] _Models = new GameObject[NumberOfAvailableModels];
	public GameObject _ModelPreview;

	public int Models_index = 0;


	// Use this for initialization
	void Start () {
		_ModelPreview.GetComponent<Image> ().sprite = _Models [Models_index].GetComponent<ModelPreviewReferencing>()._ModelSprite;
	}
	
	public void OnModelUpClicked(){
		if (Models_index < NumberOfAvailableModels - 1) {
			Models_index++;
		} else {
			Models_index = 0;
		}
		_ModelPreview.GetComponent<Image> ().sprite = _Models [Models_index].GetComponent<ModelPreviewReferencing>()._ModelSprite;
	}

	public void OnModelDownClicked(){
		if (Models_index > 0) {
			Models_index--;
		} else {
			Models_index = NumberOfAvailableModels - 1;
		}
		_ModelPreview.GetComponent<Image> ().sprite = _Models [Models_index].GetComponent<ModelPreviewReferencing>()._ModelSprite;
	}
}
>>>>>>> origin/master
