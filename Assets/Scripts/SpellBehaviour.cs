using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour
{
	[SerializeField]
	private GameObject spellDD;
	[SerializeField]
	private GameObject playerBody;
	[SerializeField]
	private float spellSpeed = 2.0f;

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
    	transform.SetParent(playerBody.transform);
    	// transform.position = playerBody.transform.position;
    	transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 0.3f, playerBody.transform.position.z);
    	// transform.position.y = 2.3f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
        	other.GetComponent<Enemy>().getHitEnemy();
        	spellDD.SetActive(false);
        	transform.SetParent(playerBody.transform);
        	// transform.position = playerBody.transform.position;
        	transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 0.3f, playerBody.transform.position.z);
        	// transform.position.y = 2.3f;
        	// other.GetComponent<Player>().getHitPlayer();
        }
        if (other.tag == "Wall") {
        	// Explode
        	Debug.Log("Wall");
        	spellDD.SetActive(false);
        	transform.SetParent(playerBody.transform);
        	// transform.position = playerBody.transform.position;
        	transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 0.3f, playerBody.transform.position.z);
        	// transform.position.y = 2.3f;
        }
        if (other.tag == "Box") {
        	// Kill the Box
        	// Debug.Log("Box");
        	spellDD.SetActive(false);
        	transform.SetParent(playerBody.transform);
        	// transform.position = playerBody.transform.position;
        	transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 0.3f, playerBody.transform.position.z);
        	// transform.position.y = 2.3f;
        	other.GetComponent<Box>().boxGetHit();
        	// other.GameObject
        }
    }
}