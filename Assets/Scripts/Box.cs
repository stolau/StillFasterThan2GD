using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
	[SerializeField]
	private GameObject childSpawn;
	[SerializeField]
	private bool isChild;
	[SerializeField]
	private GameObject box;

	private IEnumerator fadeTime;


	public void boxGetHit() {
		if(isChild) {
			childSpawn.SetActive(true);
			childSpawn.transform.parent = null;
		}
		gameObject.GetComponent<Animator>().Play("Explode");
		fadeTime = fade(2.0f);
		StartCoroutine(fadeTime);
		GetComponent<Collider>().enabled = false;
	}
	private IEnumerator fade(float time) {
		yield return new WaitForSeconds(time);
		box.SetActive(!box.activeInHierarchy);
	}

}
