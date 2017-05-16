<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arene : MonoBehaviour {
	
	public static Arene[] arenes;
	private int id;
	private string nom;
	private string scene;



	public Arene(int id, string nom, string scene){
		this.id = id;
		this.nom = nom;
		this.scene = scene;
	}

	public int getId(){
		return id;
	}

	public string getNom(){
		return nom;
	}

	public string getScene(){
		return scene;
	}
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arene : MonoBehaviour {
	
	public static Arene[] arenes;
	private int id;
	private string nom;
	private string scene;



	public Arene(int id, string nom, string scene){
		this.id = id;
		this.nom = nom;
		this.scene = scene;
	}

	public int getId(){
		return id;
	}

	public string getNom(){
		return nom;
	}

	public string getScene(){
		return scene;
	}
}
>>>>>>> origin/master
