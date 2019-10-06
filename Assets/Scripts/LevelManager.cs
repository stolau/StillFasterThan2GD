using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
	private int maxCount = 20;

	[SerializeField]
	private GameObject boxIce;
	[SerializeField]
	private GameObject boxVoid;
	[SerializeField]
	private GameObject boxSun;
	[SerializeField]
	private PlatformList[] platformList;
	[SerializeField]
	private GameObject enemy;

	private int randomX;
	private int randomZ;
	private GameObject randomObject;
	private Vector3 coords;

	private int maxCountVoid = 5;
	private int maxCountSun = 5;
	private int maxCountIce = 5;

	private int countVoid = 0;
	private int countSun = 0;
	private int countIce = 0;

	[SerializeField]
	private Text textIce;
	[SerializeField]
	private Text textVoid;
	[SerializeField]
	private Text textSun;

	[SerializeField]
	private GameObject win;
	[SerializeField]
	private GameObject lose;


	private IEnumerator spawnTimeEnemy;

    void Start() {
    	for(int i = 0; i < maxCountIce; i++) {
    		randomX = Random.Range(1, -20);
    		randomZ = Random.Range(1, 20);
    		coords.x = randomX;
    		coords.z = randomZ;
    		coords.y = 1.0f;
    		Instantiate(boxIce, coords, Quaternion.identity);
    	}
    	for(int i = 0; i < maxCountVoid; i++) {
    		randomX = Random.Range(1, -20);
    		randomZ = Random.Range(1, 20);
    		coords.x = randomX;
    		coords.z = randomZ;
    		coords.y = 1.0f;
    		Instantiate(boxVoid, coords, Quaternion.identity);
    	}
    	for(int i = 0; i < maxCountSun; i++) {
    		randomX = Random.Range(1, -20);
    		randomZ = Random.Range(1, 20);
    		coords.x = randomX;
    		coords.z = randomZ;
    		coords.y = 1.0f;
    		Instantiate(boxSun, coords, Quaternion.identity);
    	}
    	for(int i = 0; i < maxCount; i++) {
    		randomX = Random.Range(1, -20);
    		randomZ = Random.Range(1, 20);
    		randomObject = platformList[Random.Range(0, (platformList.Length))].platformPrefab;
    		coords.x = randomX;
    		coords.z = randomZ;
    		coords.y = 1.0f;
    		Instantiate(randomObject, coords, Quaternion.identity);
    	}
    	spawnTimeEnemy = spawnEnemy(15.0f);
    	StartCoroutine(spawnTimeEnemy);
    	for(int i = 0; i < 10; i++) {
    		randomX = Random.Range(1, -20);
    		randomZ = Random.Range(1, 20);
    		coords.x = randomX;
    		coords.z = randomZ;
    		coords.y = 1.0f;
    		Instantiate(enemy, coords, Quaternion.identity);
    	}
    }

    public void score(string aug) {
    	Debug.Log(aug);
    	if(aug == "Sun") {
    		if(countSun < 5) {
    			countSun += 1;
    			textSun.text = countSun.ToString();
    		}
    	}
    	if(aug == "Void") {
    		if(countVoid < 5) {
    			countVoid += 1;
    			textVoid.text = countVoid.ToString();
    		}
    	}
    	if(aug == "Ice") {
    		if(countIce < 5) {
    			countIce += 1;
    			textIce.text = countIce.ToString();
    		}
    	}
    	if(countIce >= 5 && countVoid >= 5 && countSun >= 5) {
    		// Debug.Log("Win");
    		win.SetActive(true);
    	}
    }
    public void activateLoseScreen() {
    	lose.SetActive(true);
    }

    private IEnumerator spawnEnemy(float t){
    	yield return new WaitForSeconds(t);
    	randomX = Random.Range(1, -20);
    	randomZ = Random.Range(1, 20);
    	coords.x = randomX;
    	coords.z = randomZ;
    	coords.y = 1.0f;
    	Instantiate(enemy, coords, Quaternion.identity);
    	spawnTimeEnemy = spawnEnemy(15.0f);
    	StartCoroutine(spawnTimeEnemy);
    }
    public void BackToMenu(string menu) {

		SceneManager.LoadScene(menu);
	}
}
