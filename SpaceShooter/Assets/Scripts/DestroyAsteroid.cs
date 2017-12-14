using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour {
	
	public GameObject explosion;
	public GameObject playerExplosion;
	public int weight;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("no game controller");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.tag.Equals("Boundary")){
			return;
		}
		Destroy (gameObject);
		Instantiate (explosion, transform.position, transform.rotation);
		GetComponent<AudioSource>().Play();

		if (other.tag.Equals ("Player")) {
			
			if (gameController.life == 0) 
			{
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				Destroy (other.gameObject);
			} 
			else 
			{
				gameController.LostLife ();
			}
		} 
		else 
		{
			Destroy (other.gameObject);
			if (other.tag == "Bolt") {
				gameController.AddScore (weight);
			}
		}
	}


}
