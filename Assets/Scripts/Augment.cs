using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Augment : MonoBehaviour
{
	private GameObject player;
	[SerializeField]
	private string augName;

	IEnumerator fadeTime;

	private GameObject levelManager;

	void Start() {
		player = GameObject.FindWithTag("Player");
		levelManager = GameObject.FindWithTag("LevelManager");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
        	// Debug.Log("entered");
        	fadeTime = fade(2f);
        	StartCoroutine(fadeTime);
        	player.GetComponent<PlayerShoot>().activateSpell(augName);
        	levelManager.GetComponent<LevelManager>().score(augName);
        	gameObject.SetActive(false);
            // Debug.Log("entered");
        }
    }
    private IEnumerator fade(float duration) {
		yield return new WaitForSeconds(duration);
		// player.GetComponent<PlayerShoot>().activateSpell(augName);
		// ready = true;
	}
}
