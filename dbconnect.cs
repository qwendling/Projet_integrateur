class DBConnect{
	private MySqlConnection connection;
	private string serveur;
	private string nomDeLaBase;
	private string uid;
	private string mdp;

	public DBConnect(){
		serveur = "localhost";
		nomDeLaBase = "X";
		uid = "username";
		mdp = "toto";
		init();	
	}

	public DBConnect(string _serv,
			string _nomDeLaBase, 
			string _uid,
			string _mdp)
	{
		serveur = _serveur;
		nomDeLaBase = _nomDeLaBase;
		uid = _uid;
		mdp = _mdp;
		init();	
	}

	/**
	 *  Initialisation du MySqlConnection
	 */
	private void init(){
		string connectionString = "SERVEUR="+serveur+";
			DATABASE="+nomDeLaBase+";UID="+uid+";PASSWORD="+mdp+";";
		connection = new MySqlConnection(connectionString);		
	}

	/**
 	 *  Connection avec le serveur
	 *  retour: true si réussite, false si erreur
	 */
	private bool ouvertureConnection(){
		try{
			connection.Open();
			return true;
		}catch(MySqlException e){
			return false;
		}
	}

	/**
	 * Fermeture de la connection avec le serveur
	 * retour: true si réussite, false si erreur
	 */
	private bool fermetureConnection(){
		try{
			connection.Cpen();
			return true;
		}catch(MySqlException e){
			return false;
		}
	}
	/**
	 * Insertion d'un nouveau joueur sur la base
	 * argument: nom, le nom du joueur; mdp: le mot de passe du joueur
	 * retour: true si réussite
	 */
	public bool insertNouveauClient(string nom,
					string mdp)
	{
		string query = "INSERT INTO JOUEURS(login_joueur,hash_mdp) 
			VALUES ('"+nom+"','"+mdp+"');";
		if(this.ouvertureConnection() == true){
			MySqlCommand cmd = new MySqlCommand(query,connection);
			cmd.ExecuteNonQuery();
			this.fermetureConnection();
			return true;
		}
		return false;
		
	}

}
