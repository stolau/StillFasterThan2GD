using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour {

	[SerializeField]
	private Rigidbody rb;
	[SerializeField]
	private GameObject playerBody;
	[SerializeField]
	private LayerMask layerMask;
	[SerializeField]
	private float movSpeed;


	private bool movement = true;
    // Start is called before the first frame update
    void Start() {
    	rb = GetComponent<Rigidbody>();
    	playerBody = GameObject.FindWithTag("PlayerBody");
    }

    // Update is called once per frame
    void FixedUpdate() {

    	if(Input.GetKeyDown(KeyCode.E)) {
    		Debug.Log(playerBody.transform.rotation.y);
    	}

    	if(movement) {
	    	Vector3 mousPosition = -Vector3.one;

    		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    		RaycastHit hit;

    		if(Physics.Raycast (ray, out hit, 100f, layerMask)) {

    			mousPosition = hit.point;
    			mousPosition.y = 0.55f;
    			playerBody.transform.LookAt(mousPosition, Vector3.up);
    		}

       		float h = Input.GetAxisRaw("Horizontal");
        	float v = Input.GetAxisRaw("Vertical");

       		Vector3 tempVect = new Vector3(h, 0, v);
        	tempVect = tempVect.normalized * movSpeed * Time.deltaTime;
        	if((tempVect.x > 0) || (tempVect.z > 0)) {
        		if(playerBody.transform.rotation.y >= -0.75f && playerBody.transform.rotation.y <= 0.75f) {
        			playerBody.GetComponent<Animator>().Play("Walk");
        			rb.MovePosition(transform.position + tempVect);
        		}
        		else {
        			playerBody.GetComponent<Animator>().Play("WalkBack");
        			rb.MovePosition(transform.position + tempVect * 0.5f);
        		}
        	}
        	else if(tempVect.x < 0 || (tempVect.z < 0)) {
        		if(playerBody.transform.rotation.y < -0.75f || playerBody.transform.rotation.y >= 0.75f) {
        			playerBody.GetComponent<Animator>().Play("Walk");
        			rb.MovePosition(transform.position + tempVect);
        		}
        		else {
        			playerBody.GetComponent<Animator>().Play("WalkBack");
        			rb.MovePosition(transform.position + tempVect * 0.5f);
        		}
        	}
        	else {
        		playerBody.GetComponent<Animator>().Play("Idle");
        	}
        }
    }
    public void deActiveMovement() {
    	movement = false;
    }
    public void activeMovement() {
    	movement = true;
    }
}
