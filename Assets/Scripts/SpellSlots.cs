using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellSlots {
	public string augment_Name;
	public Spell spell;
	public bool activated = false;
	public int activatedSpellCount = 0;
	public float timeStamp = 0.0f;
}
