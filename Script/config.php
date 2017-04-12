<?php
	define("BDD","LaBase");
	define("hostname","serveurmysql");
	define("dblogin","root");
	define("dbpass","mdp");

	$dsn ='mysql:dbname='.BDD.';host='.hostname;
	
	try {
   		 $dbCon = new PDO($dsn, dblogin, dbpass);
    		//$dbCon = new PDO("mysql:dbname=".BDD.";host=".hostname,dblogin,dbpass);
    		$dbCon->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    		$dbCon->setAttribute(PDO::MYSQL_ATTR_INIT_COMMAND, 'SET NAMES utf8');
    		$dbCon->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE,PDO::FETCH_ASSOC);
    		$dbCon->exec("SET CHARACTER SET utf8");
	} 
	catch (PDOException $e){
    		echo 'Connexion echouée : ' . $e->getMessage();
	}
