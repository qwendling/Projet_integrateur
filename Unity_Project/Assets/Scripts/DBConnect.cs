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

			ArmeTest temp;
			GameObject tempArme = new GameObject ();
			temp = tempArme.gameObject.AddComponent<ArmeTest> ();
			temp.GetComponent<ArmeTest> ().id = string.IsNullOrEmpty(arme[0]) ? 0 : int.Parse(arme[0])-1;
			temp.GetComponent<ArmeTest> ().nom = arme [1];
			temp.GetComponent<ArmeTest> ().cadence = string.IsNullOrEmpty(arme[2]) ? 0 : float.Parse(arme[2]);
			temp.GetComponent<ArmeTest> ().degat = string.IsNullOrEmpty(arme[3]) ? 0 : int.Parse(arme[3]);
			temp.GetComponent<ArmeTest> ().range = string.IsNullOrEmpty(arme[4]) ? 0 : int.Parse(arme[4]);
			temp.GetComponent<ArmeTest> ().vitesse = string.IsNullOrEmpty(arme[5]) ? 0 : float.Parse(arme[5]);
			temp.GetComponent<ArmeTest> ().surchauffe = string.IsNullOrEmpty(arme[6]) ? 0 : int.Parse(arme[6]);

			ArmeTest.armes.Add (temp);

			GameObject.Destroy (temp);
			GameObject.Destroy (tempArme);
		}
		*/

		// WHEN THE SERV IS DOWN
		ArmeTest temp2;
		GameObject tempArme2 = new GameObject ();
		temp2 = tempArme2.gameObject.AddComponent<ArmeTest> ();
		temp2.GetComponent<ArmeTest> ().id = 0;
		temp2.GetComponent<ArmeTest> ().nom = "Gun";
		temp2.GetComponent<ArmeTest> ().cadence = 1;
		temp2.GetComponent<ArmeTest> ().degat = 15;
		temp2.GetComponent<ArmeTest> ().range = 50;
		temp2.GetComponent<ArmeTest> ().vitesse = 5;
		temp2.GetComponent<ArmeTest> ().surchauffe = 10;

		ArmeTest.armes.Add (temp2);

		GameObject.Destroy (temp2);
		GameObject.Destroy (tempArme2);

		temp2 = null;
		tempArme2 = new GameObject ();
		temp2 = tempArme2.gameObject.AddComponent<ArmeTest> ();
		temp2.GetComponent<ArmeTest> ().id = 1;
		temp2.GetComponent<ArmeTest> ().nom = "AK";
		temp2.GetComponent<ArmeTest> ().cadence = 6;
		temp2.GetComponent<ArmeTest> ().degat = 10;
		temp2.GetComponent<ArmeTest> ().range = 50;
		temp2.GetComponent<ArmeTest> ().vitesse = 5;
		temp2.GetComponent<ArmeTest> ().surchauffe = 30;

		ArmeTest.armes.Add (temp2);

		GameObject.Destroy (temp2);
		GameObject.Destroy (tempArme2);




		SortTest temp3;
		GameObject tempSort = new GameObject ();

		//Fire
		temp3 = tempSort.gameObject.AddComponent<SortTest> ();
		temp3.GetComponent<SortTest> ().id = 3;
		temp3.GetComponent<SortTest> ().nom = "Fire";
		temp3.GetComponent<SortTest> ().cadence = 1;
		temp3.GetComponent<SortTest> ().degat = 15;
		temp3.GetComponent<SortTest> ().range = 10;
		temp3.GetComponent<SortTest> ().vitesse = 0.5f;
		temp3.GetComponent<SortTest> ().surchauffe = 10;

		SortTest.sorts.Add (temp3);
		GameObject.Destroy (temp3);
		GameObject.Destroy (tempSort);


		//Bouclier de protection
		temp3 = tempSort.gameObject.AddComponent<SortTest> ();
		temp3.GetComponent<SortTest> ().id = 4;
		temp3.GetComponent<SortTest> ().nom = "Protection";
		temp3.GetComponent<SortTest> ().cadence = 1;
		temp3.GetComponent<SortTest> ().degat = 0;
		temp3.GetComponent<SortTest> ().range = 0;
		temp3.GetComponent<SortTest> ().vitesse = 1;
		temp3.GetComponent<SortTest> ().surchauffe = 0;

		SortTest.sorts.Add (temp3);
		GameObject.Destroy (temp3);
		GameObject.Destroy (tempSort);


		//Mine
		temp3 = tempSort.gameObject.AddComponent<SortTest> ();
		temp3.GetComponent<SortTest> ().id = 5;
		temp3.GetComponent<SortTest> ().nom = "Mine";
		temp3.GetComponent<SortTest> ().cadence = 20;
		temp3.GetComponent<SortTest> ().degat = 5;
		temp3.GetComponent<SortTest> ().range = 0;
		temp3.GetComponent<SortTest> ().vitesse = 1;
		temp3.GetComponent<SortTest> ().surchauffe = 0;

		SortTest.sorts.Add (temp3);
		GameObject.Destroy (temp3);
		GameObject.Destroy (tempSort);


		//Teleportation
		temp3 = tempSort.gameObject.AddComponent<SortTest> ();
		temp3.GetComponent<SortTest> ().id = 6;
		temp3.GetComponent<SortTest> ().nom = "Teleportation";
		temp3.GetComponent<SortTest> ().cadence = 1;
		temp3.GetComponent<SortTest> ().degat = 0;
		temp3.GetComponent<SortTest> ().range = 10;
		temp3.GetComponent<SortTest> ().vitesse = 1;
		temp3.GetComponent<SortTest> ().surchauffe = 0;

		SortTest.sorts.Add (temp3);
		GameObject.Destroy (temp3);
		GameObject.Destroy (tempSort);

	}

}
