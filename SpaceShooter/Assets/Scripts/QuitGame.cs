using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	void OnDestroy() {
		Debug.Log("I'm gone! (bye, bye)");
		quit ();
	}

	void quit(){
		Application.Quit();		

	}
}
