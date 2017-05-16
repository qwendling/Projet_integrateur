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
		/*
		//WWW request = new WWW(url+"pageArmes.php");
		WWW request = new WWW("192.168.43.5/pageArmes.php");
		//Tant que la récup' n'est pas achevée
		while (!request.isDone) {}


		// Splitting des données en strings && push dans le tableau static de la classe Arme
		string reponse = request.text;
		string[] armesList = reponse.Split(';');


		string[] arme;
		for(int i = 0; i < armesList.Length-1; i++){
			arme = armesList[i].Split(',');
			for (int j = 0; j < arme.Length; j++) {
				Debug.Log (arme [j].ToString());
			}

			Arme temp;
			GameObject tempArme = new GameObject ();
			temp = tempArme.gameObject.AddComponent<Arme> ();
			temp.GetComponent<Arme> ().id = string.IsNullOrEmpty(arme[0]) ? 0 : int.Parse(arme[0])-1;
			temp.GetComponent<Arme> ().nom = arme [1];
			temp.GetComponent<Arme> ().cadence = string.IsNullOrEmpty(arme[2]) ? 0 : float.Parse(arme[2]);
			temp.GetComponent<Arme> ().degat = string.IsNullOrEmpty(arme[3]) ? 0 : int.Parse(arme[3]);
			temp.GetComponent<Arme> ().range = string.IsNullOrEmpty(arme[4]) ? 0 : int.Parse(arme[4]);
			temp.GetComponent<Arme> ().vitesse = string.IsNullOrEmpty(arme[5]) ? 0 : float.Parse(arme[5]);
			temp.GetComponent<Arme> ().surchauffe = string.IsNullOrEmpty(arme[6]) ? 0 : int.Parse(arme[6]);
			temp.GetComponent<Arme> ().Anim = string.IsNullOrEmpty(arme[7]) ? null : int.Parse(arme[7]);

			Arme.armes.Add (temp);

			GameObject.Destroy (temp);
			GameObject.Destroy (tempArme);
		}
		*/

		// WHEN THE SERV IS DOWN
		Arme temp2;
		GameObject tempArme2 = new GameObject ();
		temp2 = tempArme2.gameObject.AddComponent<Arme> ();
		temp2.GetComponent<Arme> ().id = 0;
		temp2.GetComponent<Arme> ().nom = "Gun";
		temp2.GetComponent<Arme> ().cadence = 1;
		temp2.GetComponent<Arme> ().degat = 15;
		temp2.GetComponent<Arme> ().range = 50;
		temp2.GetComponent<Arme> ().vitesse = 5;
		temp2.GetComponent<Arme> ().surchauffe = 10;
		temp2.GetComponent<Arme> ().Anim = AnimArme.weapon;

		Arme.armes.Add (temp2);

		GameObject.Destroy (temp2);
		GameObject.Destroy (tempArme2);

		temp2 = null;
		tempArme2 = new GameObject ();
		temp2 = tempArme2.gameObject.AddComponent<Arme> ();
		temp2.GetComponent<Arme> ().id = 1;
		temp2.GetComponent<Arme> ().nom = "AK";
		temp2.GetComponent<Arme> ().cadence = 6;
		temp2.GetComponent<Arme> ().degat = 10;
		temp2.GetComponent<Arme> ().range = 50;
		temp2.GetComponent<Arme> ().vitesse = 5;
		temp2.GetComponent<Arme> ().surchauffe = 30;
		temp2.GetComponent<Arme> ().Anim = AnimArme.ak;

		Arme.armes.Add (temp2);

		GameObject.Destroy (temp2);
		GameObject.Destroy (tempArme2);




		Sort temp3;
		GameObject tempSort = new GameObject ();

		//Fire
		temp3 = tempSort.gameObject.AddComponent<Sort> ();
		temp3.GetComponent<Sort> ().id = 2;
		temp3.GetComponent<Sort> ().nom = "Fire";
		temp3.GetComponent<Sort> ().cadence = 1;
		temp3.GetComponent<Sort> ().degat = 15;
		temp3.GetComponent<Sort> ().range = 10;
		temp3.GetComponent<Sort> ().vitesse = 0.5f;
		temp3.GetComponent<Sort> ().surchauffe = 10;
		temp3.GetComponent<Sort> ().Anim = AnimArme.ball;

		Sort.sorts.Add (temp3);
		GameObject.Destroy (temp3);
		GameObject.Destroy (tempSort);


		//Bouclier de protection
		temp3 = tempSort.gameObject.AddComponent<Sort> ();
		temp3.GetComponent<Sort> ().id = 3;
		temp3.GetComponent<Sort> ().nom = "Protection";
		temp3.GetComponent<Sort> ().cadence = 1;
		temp3.GetComponent<Sort> ().degat = 0;
		temp3.GetComponent<Sort> ().range = 0;
		temp3.GetComponent<Sort> ().vitesse = 1;
		temp3.GetComponent<Sort> ().surchauffe = 0;
		temp3.GetComponent<Sort> ().Anim = AnimArme.ball;

		Sort.sorts.Add (temp3);
		GameObject.Destroy (temp3);
		GameObject.Destroy (tempSort);


		//Mine
		temp3 = tempSort.gameObject.AddComponent<Sort> ();
		temp3.GetComponent<Sort> ().id = 4;
		temp3.GetComponent<Sort> ().nom = "Mine";
		temp3.GetComponent<Sort> ().cadence = 20;
		temp3.GetComponent<Sort> ().degat = 5;
		temp3.GetComponent<Sort> ().range = 0;
		temp3.GetComponent<Sort> ().vitesse = 1;
		temp3.GetComponent<Sort> ().surchauffe = 0;
		temp3.GetComponent<Sort> ().Anim = AnimArme.ball;

		Sort.sorts.Add (temp3);
		GameObject.Destroy (temp3);
		GameObject.Destroy (tempSort);


		//Teleportation
		temp3 = tempSort.gameObject.AddComponent<Sort> ();
		temp3.GetComponent<Sort> ().id = 5;
		temp3.GetComponent<Sort> ().nom = "Teleportation";
		temp3.GetComponent<Sort> ().cadence = 1;
		temp3.GetComponent<Sort> ().degat = 0;
		temp3.GetComponent<Sort> ().range = 10;
		temp3.GetComponent<Sort> ().vitesse = 1;
		temp3.GetComponent<Sort> ().surchauffe = 0;
		temp3.GetComponent<Sort> ().Anim = AnimArme.ball;

		Sort.sorts.Add (temp3);
		GameObject.Destroy (temp3);
		GameObject.Destroy (tempSort);

	}

}
