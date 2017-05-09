using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DBConnect {

	public DBConnect(){

	}


	/** 
	 * initialise le tableau static Arme.armes avec le contenu de la BDD
	 **/
	public void init(string url){		



		WWW request = new WWW(url+"pageArmes.php");

		//Tant que la récup' n'est pas achevée
		while (!request.isDone) {}


		// Splitting des données en strings && push dans le tableau static de la classe Arme
		string reponse = request.text;
		string[] armes = reponse.Split(';');
		string[] arme;
		ArmeTest.armes = new ArmeTest[armes.Length];
		int i = 0;
		for(i = 0; i<armes.Length; i++){
			arme = armes[i].Split(',');
			ArmeTest.armes[i] = new ArmeTest(int.Parse(arme[0]), arme[1], float.Parse(arme[2]), int.Parse(arme[3]), int.Parse(arme[4]), float.Parse(arme[5]));
		}

		/*
		//Pour les tests tant qu'on a pas le serveur web
		Arme arme = new Arme(0,"toto",3.4,10,10,3.4);
		Arme.armes = new Arme[1];
		Arme.armes[0] = arme;
		*/

	}

}
