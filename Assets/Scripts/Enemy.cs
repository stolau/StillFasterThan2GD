using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private GameObject enemySpell;
	private Rigidbody rb;
	private GameObject player;
	private Vector3 target;
	private float randX;
	private float randZ;
	private IEnumerator changeTimer;
	private float tsSpell;
	private bool walking = true;
	private IEnumerator spellCast;
	private IEnumerator dieCast;
	[SerializeField]
	private GameObject enemyBody;
	[SerializeField]
	private GameObject enemy;

	private bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
    	tsSpell = Random.Range(0.0f, 10.0f);
    	rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        randX = Random.Range(0.0f, 40.0f);
        randZ = Random.Range(0.0f, 40.0f);
        target = new Vector3(randX, 0.8f, randZ);
        changeTimer = change(3f);
        StartCoroutine(changeTimer);
    }

    // Update is called once per frame
    void Update()
    {
    	if(alive) {
    		float dist = Vector3.Distance(player.transform.position, transform.position);
        	if(dist < 6.0f) {
        		enemy.transform.LookAt(player.transform);
        		if (tsSpell < Time.time) {
        			walking = false;
        			enemyBody.GetComponent<Animator>().Play("Attack");
        			// Activate Projectile
        			Debug.Log("Shooting");
        			spellCast = spellCastIE(1.5f);
        			tsSpell = Time.time + 7.0f;
        			StartCoroutine(spellCast);
        			enemySpell.SetActive(true);
        		}
        	}
       		else {
        		enemy.transform.LookAt(target);
        	}
        	if(walking) {
        		enemyBody.GetComponent<Animator>().Play("Walk");
        		rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 1.5f);
        	}
        }
        // rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 1f);
    }
    public void getHitEnemy() {
    	alive = false;
    	enemyBody.GetComponent<Animator>().Play("Die");
    	GetComponent<BoxCollider>().enabled = false;
    	dieCast = die(1.5f);
    	StartCoroutine(dieCast);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall") {
        	transform.LookAt(2 * transform.position - target);
        }
    }
    private IEnumerator die(float timer) {
    	yield return new WaitForSeconds(timer);
    	enemy.SetActive(false);

    }
    private IEnumerator spellCastIE(float timer) {
    	yield return new WaitForSeconds(timer);
    	walking = true;
    }
    private IEnumerator change(float timer){
    	yield return new WaitForSeconds(timer);
        randX = Random.Range(0.0f, 40.0f);
        randZ = Random.Range(0.0f, 40.0f);
        target = new Vector3(randX, 0.8f, randZ);
        changeTimer = change(3f);
        StartCoroutine(changeTimer);
    }   
}
