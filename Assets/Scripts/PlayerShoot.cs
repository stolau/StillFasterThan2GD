using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	/*[SerializeField]
	private GameObject[] slots;
	[SerializeField]
	private GameObject[] powers;*/
	[SerializeField]
	private List<GameObject> slots;
	[SerializeField]
	private List<SpellSlots> spellSlots;

	private List<SpellSlots> activatedSpells;

	private GameObject playerBody;
	private GameObject player;

	private IEnumerator attackDur;

	private bool ready = true;
	private bool updated = false;

	void Start() {
		playerBody = GameObject.FindWithTag("PlayerBody");
		player = GameObject.FindWithTag("Player");
		activatedSpells = new List<SpellSlots>();
		// attackDur = stunned(1f);
	}

	void Update() {
		if(updated) {
			showSpells();
		}

		if(ready) {
			// Debug.Log(activatedSpells[0] == null);
			if(Input.GetMouseButtonDown(0)) {
				if(activatedSpells.Count > 0 && (activatedSpells[0].timeStamp < Time.time)) {
					activatedSpells[0].timeStamp = Time.time + 5.0f;
					playerBody.GetComponent<Animator>().Play("AttackLeft");
					player.GetComponent<PlayMovement>().deActiveMovement();
					ready = false;
					// activatedSpells[0].spell.spellIcon.SetActive(false);
					slots[0].SetActive(false);
					attackDur = stunned(1.5f);
					StartCoroutine(attackDur);
					activatedSpells[0].spell.projectile.SetActive(true);
				}
			}
			if(Input.GetMouseButtonDown(1)) {
				if(activatedSpells.Count > 1 && (activatedSpells[1].timeStamp < Time.time)) {
					activatedSpells[1].timeStamp = Time.time + 5.0f;
					playerBody.GetComponent<Animator>().Play("AttackRight");
					player.GetComponent<PlayMovement>().deActiveMovement();
					ready = false;
					// activatedSpells[0].spell.spellIcon.SetActive(false);
					slots[1].SetActive(false);
					attackDur = stunned(1.5f);
					StartCoroutine(attackDur);
					activatedSpells[1].spell.projectile.SetActive(true);
				}
			}
			/*
			if(Input.GetMouseButtonDown(1)) {
				playerBody.GetComponent<Animator>().Play("AttackRight");
				player.GetComponent<PlayMovement>().deActiveMovement();
				ready = false;
				attackDur = stunned(1.5f);
				StartCoroutine(attackDur);
			}*/
			if(Input.GetKeyDown(KeyCode.Q)) {
				swapOrder();
			}
		}
	}
	private IEnumerator stunned(float duration) {
		yield return new WaitForSeconds(duration);
		player.GetComponent<PlayMovement>().activeMovement();
		slots[0].SetActive(true);
		slots[1].SetActive(true);
		ready = true;
	}
	private void swapOrder() {
		// Swaps order of weapons
		// SpellSlots pos1 = spellSlots.removeAt(0);
		// spellSlots.Add(pos1);
		if(activatedSpells.Count == 3) {
			SpellSlots pos1 = activatedSpells[0];
			SpellSlots pos2 = activatedSpells[1];
			SpellSlots pos3 = activatedSpells[2];
			activatedSpells = new List<SpellSlots>();
			activatedSpells.Add(pos2);
			activatedSpells.Add(pos3);
			activatedSpells.Add(pos1);
			showSpells();
		}
		if(activatedSpells.Count == 2) {
			SpellSlots pos1 = activatedSpells[0];
			SpellSlots pos2 = activatedSpells[1];
			activatedSpells = new List<SpellSlots>();
			activatedSpells.Add(pos2);
			activatedSpells.Add(pos1);
			showSpells();
		}

	}
	private void showSpells() {
		for(int i = 0; i < activatedSpells.Count; i++) {
			activatedSpells[i].spell.spellIcon.transform.SetParent(slots[i].transform);
			activatedSpells[i].spell.spellIcon.transform.position = slots[i].transform.position;
			activatedSpells[i].spell.spellIcon.SetActive(true);
		}
		updated = false;
	}
	public void activateSpell(string augmentName) {
		bool checker = true;
		for(int i = 0; i < spellSlots.Count; i++) {
			if(spellSlots[i].augment_Name == augmentName) {
				if(activatedSpells.Count > 0) {
					for(int j = 0; j < activatedSpells.Count; j++) {
						if(activatedSpells[j].augment_Name == augmentName) {
							checker = false;
						}
					}
				}
				if(checker && activatedSpells.Count < 3){
					spellSlots[i].activated = true;
					spellSlots[i].activatedSpellCount =+ 1;
					activatedSpells.Add(spellSlots[i]);
					updated = true;
				}
				else if((!checker || activatedSpells.Count >= 3) && spellSlots[i].activatedSpellCount < 5) {
					spellSlots[i].activatedSpellCount =+ 1;
				}
			}
		}
	}
}
