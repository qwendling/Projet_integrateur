<?php
	include "config.php";
	
	$requete = $dbCon->prepare("SELECT * FROM ARMES");
	$requete->execute();
	$donnees=$requete->fetchAll();
    	$requete->closeCursor();
	foreach ($donnees as $row) {
		echo $row['id_arme'].",".$row['nom_arme'].",".$row['cadence_arme'].",".$row['degats_arme'].",".$row['range_arme'].",".$row['vitesse_bullet_arme'].",".$row['surchauffe_arme'].';';
	}
	
