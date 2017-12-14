using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	void Start () {
		if (this.tag != "Bolt")
			speed = speed * Random.Range (1, 10) / 10;
		Vector3 speedV = new Vector3 (0.0f, 0.0f, speed);
		GetComponent<Rigidbody>().velocity = transform.forward=speedV;
		//GetComponent<Rigidbody> ().velocity.z = speed;
		//GetComponent<Rigidbody> ().velocity.y = transform.forward.y = speed;
		//GetComponent<Rigidbody> ().velocity.x = transform.forward.x = speed;
		
	}

}
