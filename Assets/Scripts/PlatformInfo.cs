using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInfo : MonoBehaviour
{
	[SerializeField]
	private int size;
	[SerializeField]
	private int[] coords;

	public int[] getCoords() {
		return coords;
	}
	public int getSize() {
		return size;
	}
}
