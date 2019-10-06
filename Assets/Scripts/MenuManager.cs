using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public void newGameBtn(string newGameLevel) {

		SceneManager.LoadScene(newGameLevel);
	}
	public void quit() {
		Application.Quit();
	}

}


