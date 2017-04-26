public class Arme{
	public static Arme[] armes;


	private int id;
	private string nom;
	private float cadence;
	private int degat;
	private int range;
	private float vitesseBullet;
	public Arme(id,nom,cadence,degat,range,vitesseBullet){
		this.id = id;
		this.nom = nom;
		this.cadence =cadence;
		this.degat = degat;
		this.range = range;
		this.vitesseBullet = vitesseBullet;
	}

	public int getId(){
		return id;
	}

	public string getNom(){
		return nom;
	}

	public float getCadence(){
		return cadence;
	}

	public int getDegat(){
		return degat;
	}
	public int getRange(){
		return range;
	}

	public float getVitesseBullet(){
		return vitesseBullet;
	}



}
