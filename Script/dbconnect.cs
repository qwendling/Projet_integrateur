class DBConnect{
	
	/**
	 * initialise les deux tableau static, Arme.armes et Arene.arenes, avec le contenu de la BDD
	 */
	public static void init(string url){
		

		WWW request = new WWW(url+"pageArmes.php");

		string reponse = request.text;
		string[] armes = reponse.Split(';');
		string[] arme;
		Arme.armes = new Arme[armes.Length];
		int i = 0;
		for(i = 0;i<armes.Length;i++){
			arme = armes[i].Split(',');
			Arme.armes[i] = new Arme(Int32.Parse(arme[0]),arme[1],float.Parse(arme[2]),Int32.Parse(arme[3]),Int32.Parse(arme[4]),float.Parse(arme[5]));
		}
		
		request = new WWW(url+"pageArenes.php");

		reponse = request.text;
		string[] arenes = reponse.Split(';');
		string[] arene;
		Arene.arenes = new Arene[arenes.Length];
		int i = 0;
		for(i = 0;i<arene.Length;i++){
			arene = arene[i].Split(',');
			Arene.arenes[i] = new Arene(Int32.Parse(arene[0]),arene[1],arene[2]);
		}

		
		/*
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
