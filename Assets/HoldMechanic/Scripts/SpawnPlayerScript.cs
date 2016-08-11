using UnityEngine;
using System.Collections;

public class SpawnPlayerScript : MonoBehaviour {

	public GameObject levelStart;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player.transform.position = playerSpawnPosition();
		player.SetActive (true);
	}

	Vector3 playerSpawnPosition() {
		return levelStart.transform.position;
	}
}
