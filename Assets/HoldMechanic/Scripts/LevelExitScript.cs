using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Collider))]
public class LevelExitScript : MonoBehaviour {

	Collider levelEndCollider;
	LayerMask playerLayer;

	void Start () {
		levelEndCollider = gameObject.GetComponent<Collider>();
		playerLayer = LayerMask.NameToLayer ("Player");
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.layer == playerLayer && playerIsWithinBounds(other)) {
			SceneManager.LoadScene ("MainScene");
		}
	}

	bool playerIsWithinBounds (Collider playerCollider) {
		return (playerIsWithinX(playerCollider) && playerIsWithinZ(playerCollider));
	}

	bool playerIsWithinX(Collider playerCollider) {
		return playerCollider.bounds.min.x >= levelEndCollider.bounds.min.x && playerCollider.bounds.max.x <= levelEndCollider.bounds.max.x;
	}

	bool playerIsWithinZ(Collider playerCollider) {
		return playerCollider.bounds.min.z >= levelEndCollider.bounds.min.z && playerCollider.bounds.max.z <= levelEndCollider.bounds.max.z;
	}
}
