using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject hazard2;
	public GameObject hazard3;
	public int hazardCount;
	public Vector3 spawnValues;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public float endwait;

	private int score;
	public int life;
	public Text scoreText;
	public Text lifeText;
	public Text endText;

	private float nbWave = 0;
	// Use this for initialization
	void Start () {
		score = 0;
		life = 3;
		UpdateScore ();
		UpdateLife ();
		StartCoroutine(SpawnWaves ());
	}

	void Update(){
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			StartCoroutine (QuitApp("  A Bientôt",false));
		}
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject == null) {
			StartCoroutine (QuitApp("Game Over",true));
		}
	}
	
	// Update is called once per frame
	IEnumerator SpawnWaves () {
		float nbSpawn = 0;
		yield return new WaitForSeconds (startWait );
		for (int i = 0;i<hazardCount;i++) {
			float wait = spawnWait+spawnWait* (1/(1+nbSpawn));
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Vector3 spawnPosition2 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Vector3 spawnPosition3 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (wait);
			Instantiate (hazard2, spawnPosition2, spawnRotation);
			yield return new WaitForSeconds (wait);
			Instantiate (hazard3, spawnPosition3, spawnRotation);
			yield return new WaitForSeconds (wait);
			nbSpawn++;
		}
		nbWave++;
		yield return new WaitForSeconds (waveWait + waveWait * (1/(1+nbWave)));
	}

	public void AddScore (int scoreToAdd){
		score += scoreToAdd + score*scoreToAdd/100;
		UpdateScore ();
	}

	public void LostLife (){
		life--;
		UpdateLife ();
	}

	void UpdateScore (){
		if (scoreText != null) {
			scoreText.text = "Score : "+score.ToString ();
		}
	}

	void UpdateLife (){
		if (lifeText != null) {
			lifeText.text = "<3 : "+life.ToString ();
		}
	}

	IEnumerator QuitApp (string message, bool islong) {
		if(islong)
			yield return new WaitForSeconds (endwait);
		endText.text = message;
		yield return new WaitForSeconds (endwait);
		Application.Quit ();
	}
}
