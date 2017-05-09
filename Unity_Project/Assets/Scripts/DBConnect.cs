using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DBConnect {

	public DBConnect(){
	}


	/** 
	 * initialise les deux tableau static, Arme.armes et Arene.arenes, avec le contenu de la BDD
	 **/
	public void init(string url){		
		
		WWW request = new WWW(url+"pageArmes.php");

		string reponse = request.text;
		string[] armes = reponse.Split(';');
		string[] arme;
		ArmeTest.armes = new ArmeTest[armes.Length];
		int i = 0;
		for(i = 0; i<armes.Length; i++){
			arme = armes[i].Split(',');
			ArmeTest.armes[i] = new ArmeTest(int.Parse(arme[0]),arme[1],float.Parse(arme[2]),int.Parse(arme[3]),int.Parse(arme[4]),float.Parse(arme[5]));
		}

		/*
		request = new WWW(url+"pageArenes.php");

		reponse = request.text;
		string[] arenes = reponse.Split(';');
		string[] arene;
		Arene.arenes = new Arene[arenes.Length];
		for(i = 0; i < arenes.Length; i++){
			arene = arenes[i].Split(',');
			Arene.arenes[i] = new Arene(int.Parse(arene[0]),arene[1],arene[2]);
		}

		
		//Pour les tests tant qu'on a pas le serveur web
		Arme arme = new Arme(0,"toto",3.4,10,10,3.4);
		Arme.armes = new Arme[1];
		Arme.armes[0] = arme;

		Arene arene = new Arene(0,"nom","scene");
		Arene.arenes = new Arene[1];
		Arene.arenes[0] = arene
		*/

	}

	
}
