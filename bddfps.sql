/** code mysql **/
DROP TABLE IF EXISTS CLASSES;
DROP TABLE IF EXISTS ARMES;
DROP TABLE IF EXISTS JOUEURS;
DROP TABLE IF EXISTS AVATARS;
DROP TABLE IF EXISTS ARENES;



/** tables **/
CREATE TABLE ARMES(
	id_arme int PRIMARY KEY NOT NULL AUTO_INCREMENT,
	nom_arme varchar(256),
	cadence_arme decimal(5,3),
	degats_arme int,
	vitesse_bullet_arme decimal(5,3),
	range_arme int
)ENGINE = INNODB;

CREATE TABLE JOUEURS(
	id_joueur int PRIMARY KEY NOT NULL AUTO_INCREMENT,
	login_joueur varchar(256),
	hash_mdp varchar(256)
)ENGINE = INNODB;


CREATE TABLE AVATARS(
	id_avatar int PRIMARY KEY NOT NULL AUTO_INCREMENT,
	nom_avatar varchar(256),
	modele_avatar varchar(256)
)ENGINE = INNODB;

CREATE TABLE CLASSES(
	id_classe int PRIMARY KEY NOT NULL AUTO_INCREMENT,
	nom_classe varchar(256),
	id_joueur int,
	id_armeA int,
	id_armeB int,
	id_armeC int,
	id_avatar int,
	rgb_avatar int
)ENGINE = INNODB;

/** Pas forcement necessaire **/
CREATE TABLE ARENES(
	id_arene int PRIMARY KEY NOT NULL AUTO_INCREMENT,
	nom_arene varchar(256),
	scene_arene varchar(256)
)ENGINE = INNODB;

/** contraintes **/
ALTER TABLE CLASSES ADD CONSTRAINT fkJoueur FOREIGN KEY(id_joueur) REFERENCES JOUEURS(id_joueur);
ALTER TABLE CLASSES ADD CONSTRAINT fkarmeA FOREIGN KEY(id_armeA) REFERENCES ARMES(id_arme);
ALTER TABLE CLASSES ADD CONSTRAINT fkarmeB FOREIGN KEY(id_armeB) REFERENCES ARMES(id_arme);
ALTER TABLE CLASSES ADD CONSTRAINT fkarmeC FOREIGN KEY(id_armeC) REFERENCES ARMES(id_arme);
ALTER TABLE CLASSES ADD CONSTRAINT fkavatar FOREIGN KEY(id_avatar) REFERENCES AVATAR(id_avatar);
