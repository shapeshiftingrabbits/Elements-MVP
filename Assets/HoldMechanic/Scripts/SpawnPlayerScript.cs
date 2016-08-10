using UnityEngine;
using System.Collections;

public class SpawnPlayerScript : MonoBehaviour {

	public GameObject levelStart;
	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		Instantiate (playerPrefab, playerSpawnPosition (), Quaternion.identity);
	}

	Vector3 playerSpawnPosition() {
		return levelStart.transform.position;
	}
}
