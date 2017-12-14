using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

	void Update () {
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
		#else
		if(Input.GetTouch(0).position.x>0 && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

	
		#endif
	}
	void FixedUpdate () {

		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		float moveHorizontale = Input.GetAxis ("Horizontal");
		float moveVerticale = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontale*speed, 0.0f, moveVerticale*speed);
		GetComponent<Rigidbody>().velocity = movement;

		GetComponent<Rigidbody> ().position = new Vector3 (Mathf.Clamp(GetComponent<Rigidbody> ().position.x,boundary.xMin,boundary.xMax),0.0f, Mathf.Clamp(GetComponent<Rigidbody> ().position.z,boundary.zMin,boundary.zMax));
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);
		#else

		Vector3 movement = new Vector3 (Input.acceleration.x*speed, 0.0f, Input.acceleration.y*speed);
		GetComponent<Rigidbody>().velocity = movement;

		GetComponent<Rigidbody> ().position = new Vector3 (Mathf.Clamp(GetComponent<Rigidbody> ().position.x,boundary.xMin,boundary.xMax),0.0f, Mathf.Clamp(GetComponent<Rigidbody> ().position.z,boundary.zMin,boundary.zMax));
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);

		#endif

	}


}
