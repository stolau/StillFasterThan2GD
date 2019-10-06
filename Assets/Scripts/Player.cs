using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField]
	private Slider hpSlider;
    // Start is called before the first frame update

    private float hitPoints = 10f;
    private float maxHp;

    void Start()
    {
     	maxHp = hitPoints;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getHitPlayer() {
    	hitPoints = hitPoints - 1f;
    	hpSlider.value = (hitPoints / maxHp);
    	if(hitPoints <= 0.0f) {
    		Debug.Log("Lose");
    		GameObject levelManager = GameObject.FindWithTag("LevelManager");
    		levelManager.GetComponent<LevelManager>().activateLoseScreen();
    		GameObject player = GameObject.FindWithTag("Player");
    		player.transform.position = new Vector3(0f, -50f, 0f);
    		// player.SetActive(false);
    		// gameObject.SetActive(false);
    	}
    }
    public void gainHitPointsPlayer() {
    	if(hitPoints < 10) {
    		hitPoints = hitPoints + 1f;
    		hpSlider.value = (hitPoints / maxHp);
    	}
    	// hitPoints = hitPoints + 1;
    }
}
