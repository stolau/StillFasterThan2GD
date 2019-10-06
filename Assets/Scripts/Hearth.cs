using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour
{
	private GameObject player;

	IEnumerator fadeTime;

	void Start() {
		player = GameObject.FindWithTag("Player");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
        	// Debug.Log("entered");
        	fadeTime = fade(2f);
        	StartCoroutine(fadeTime);
        	player.GetComponent<Player>().gainHitPointsPlayer();
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