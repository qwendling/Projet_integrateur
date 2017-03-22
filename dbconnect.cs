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
		string connectionString = "SERVEUR="+serveur+";"+
			+"DATABASE="+nomDeLaBase+";UID="+uid+";PASSWORD="+mdp+";";
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
	 * arguments: nom: le nom du joueur; mdp: le mot de passe du joueur
	 * retour: true si réussite
	 */
	public bool insertNouveauClient(string nom,
					string mdp)
	{
		string query = "INSERT INTO JOUEURS(login_joueur,hash_mdp) "+
		"VALUES ('"+nom+"','"+mdp+"');";
		if(this.ouvertureConnection() == true){
			MySqlCommand cmd = new MySqlCommand(query,connection);
			cmd.ExecuteNonQuery();
			this.fermetureConnection();
			return true;
		}
		return false;
		
	}


	/**
	 * Insertion d'une nouvelle classe sur la base
	 * arguments: les champs d'un n-uplets
	 * retourn: true si réussite
	 */
	public bool insertClass(int idJoueuer,
				string nomClass,
				int id_armeA,
				int id_armeB,
				int id_armeC,
				int id_avatar,
				int rgb_avatar)
	{
		string query = "INSERT INTO CLASSES(nom_classe,id_joueur,"
		+"id_armeA,id_armeB,id_armeC,id_avatar,rgb_avatar)"+
		+"VALUES('"+nomClass+"',"+id_armeA+","+id_armeB+","+id_armeC
		+","+id_avatar+","+rgb_avatar+");";
		if(this.ouvertureConnection() == true){
			MySqlCommand cmd = new MySqlCommand(query,connection);
			cmd.ExecuteNonQuery();
			this.fermetureConnection();
			return true;
		}
		return false;
	}
	
	/**
	 * Mettre à jour une classe dans la base
	 * arguments: champs d'un n-uplets
	 * retourn: true si réussite
	 */
	 public bool updateClass(int idClass,
				string nomClass,
				int id_armeA,
				int id_armeB,
				int id_armeC,
				int id_avatar,
				int rgb_avatar)
	{
		string query ="UPDATE CLASSES"
		+"SET id_armeA="+id_armeA+",id_armeB="+id_armeB+","
		+"id_armeC="+id_armeC+",id_avatar="+id_avatar+","
		+"nom_classe = '"+nomClass+"',"
		+"rgb_avatar="+rgb_avatar+" WHERE id_classe = "+idClass+";";
		if(this.ouvertureConnection() == true){
			MySqlCommand cmd = new MySqlCommand(query,connection);
			cmd.ExecuteNonQuery();
			this.fermetureConnection();
			return true;
		}
		return false;
	}
	/**
	 * Suppression d'une classe dans la base
	 * argument: int-id de la classe sur le serveur
	 * retour: true si ok
	 */	
	 /**
	 * Suppression d'une classe dans la base
	 * argument: int-id de la classe sur le serveur
	 * retour: true si ok
	 */	
	  public bool deleteClass(int idClass)
	{
		string query ="DELETE FROM CLASSES WHERE id_classe = "+idClass+";";
		if(this.ouvertureConnection() == true){
			MySqlCommand cmd = new MySqlCommand(query,connection);
			cmd.ExecuteNonQuery();
			this.fermetureConnection();
			return true;
		}
		return false;
	}
		  
	/**
	 * Selectionne les entrées dans la table ARMES
	 * retour: -une strnig vide si échec ou si la table est vide
	 *	   -une string contenant les valeurs de chaque n-uplet ou deux n-uplets sont séparé par un /
	 * TODO: faire un format de retour plus facilement exploitable
	 */
	public string selectArme()
	{
		string result = "";
		string query ="SELECT * FROM ARMES;";
		if(this.ouvertureConnection() == true){
			MySqlCommand cmd = new MySqlCommand(query,connection);
			cmd.ExecuteNonQuery();
			MySqlDataReader reader = cmd.ExecuteReader();
			if(reader.Read()){
				result = reader.ToString();
			}
			while (reader.Read()){
    				result = result+"/"+reader.ToString();
			}
			this.fermetureConnection();
		}
		return result;
	}
	/**
	 * Selectionne les entrées dans la table ARENES
	 * retour: -une strnig vide si échec ou si la table est vide
	 *	   -une string contenant les valeurs de chaque n-uplet ou deux n-uplets sont séparé par un /
	 * TODO: faire un format de retour plus facilement exploitable
	 */
	public string selectArene()
	{
		string result = "";
		string query ="SELECT * FROM ARENES;";
		if(this.ouvertureConnection() == true){
			MySqlCommand cmd = new MySqlCommand(query,connection);
			cmd.ExecuteNonQuery();
			MySqlDataReader reader = cmd.ExecuteReader();
			if(reader.Read()){
				result = reader.ToString();
			}
			while (reader.Read()){
    				result = result+"/"+reader.ToString();
			}
			this.fermetureConnection();
		}
		return result;
	}

							

}
