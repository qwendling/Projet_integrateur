class DBConnect{
	
	/**
	 * initialise les deux tableau static, Arme.armes et Arene.arenes, avec le contenu de la BDD
	 */
	public static void init(){
		/*



		*/
		
		//Pour les tests tant qu'on a pas le serveur web
		Arme arme = new Arme(0,"toto",3.4,10,10);
		Arme.armes = new Arme[1];
		Arme.armes[0] = arme;

		Arene arene = new Arene(0,"nom","scene");
		Arene.arenes = new Arene[1];
		Arene.arenes[0] = arene
		

	}

	
}
