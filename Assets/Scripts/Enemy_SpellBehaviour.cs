using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpellBehaviour : MonoBehaviour
{
	[SerializeField]
	private GameObject spellDD;
	[SerializeField]
	private GameObject enemyBody;
	[SerializeField]
	private float spellSpeed = 1.0f;

	private bool activated = false;
	[SerializeField]
	private Collider collider;

	private IEnumerator spellDur;



    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        spellDur = spellTime(3f);
        StartCoroutine(spellDur);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.parent = null;
        collider.enabled = true;
        transform.Translate(Vector3.forward * Time.deltaTime * spellSpeed);    		
    }
    private IEnumerator spellTime(float duration) {
    	yield return new WaitForSeconds(duration);
    	spellDD.SetActive(false);
    	transform.SetParent(enemyBody.transform);
    	transform.position = enemyBody.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
        	other.GetComponent<Player>().getHitPlayer();
        	spellDD.SetActive(false);
        	transform.SetParent(enemyBody.transform);
        	transform.position = enemyBody.transform.position;
        	// other.GetComponent<Player>().getHitPlayer();
        }
        if (other.tag == "Wall") {
        	// Explode
        	Debug.Log("Wall");
        	spellDD.SetActive(false);
        	transform.SetParent(enemyBody.transform);
        	transform.position = enemyBody.transform.position;
        }
        if (other.tag == "Box") {
        	// Kill the Box
        	// Debug.Log("Box");
        	spellDD.SetActive(false);
        	transform.SetParent(enemyBody.transform);
        	transform.position = enemyBody.transform.position;
        	other.GetComponent<Box>().boxGetHit();
        	// other.GameObject
        }
    }
}