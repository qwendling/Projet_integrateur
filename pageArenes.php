<?php
	include "config.php";
	
	$requete = $dbCon->prepare("SELECT * FROM ARENES");
	$requete->execute();
	$donnees=$requete->fetchAll();
    	$requete->closeCursor();
	foreach ($donnees as $row) {
		echo $row['id_arene'].",".$row['nom_arene'].",".$row['scene_arene'].';';
	}
	
	



	






